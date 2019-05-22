using System;
using NUnit.Framework;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace Zenject
{
	public abstract class UnitTestBase : ZenjectUnitTestFixture
	{
		protected List<BindingInstaller> installers = new List<BindingInstaller>();


		public UnitTestBase()
		{
			//installers.Add(new Ampligence.Installers.BasicInstaller());
			SetInstallers();


		}



		public static void Print(object obj)
		{
			Console.WriteLine(obj.ToString());
		}


		public static void AssertPrintEqual(object result, object expected)
		{
			Print(result);
			Assert.AreEqual(result.ToString(), expected.ToString());
		}


		public void AssertListSame<T>(IEnumerable<T> a, IEnumerable<T> b)
		{
			bool ans;
			ans = a.SequenceEqual(b);
			Assert.True(ans);
		}


		public void AssertListNotSame<T>(IEnumerable<T> a, IEnumerable<T> b)
		{
			bool ans;
			ans = a.SequenceEqual(b);
			Assert.False(ans);
		}







		public override void Setup()
		{
			base.Setup();
			DoBinding();
			Container.Inject(this);
		}





		protected virtual void DoBinding()
		{
			foreach (var installer in installers)
			{
				installer.Container = this.Container;
				installer.Bind();
			}
		}




		/// <summary>
		/// installers.Add(BindingInstaller)
		/// </summary>
		protected abstract void SetInstallers();
	}
}
