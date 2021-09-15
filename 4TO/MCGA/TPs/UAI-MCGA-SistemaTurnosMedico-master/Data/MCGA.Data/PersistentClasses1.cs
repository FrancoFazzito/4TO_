using System;
using DevExpress.Xpo;

namespace MCGA.Data
{

	public class PersistentClasses1 : XPObject
	{
		public PersistentClasses1() : base()
		{
			// This constructor is used when an object is loaded from a persistent storage.
			// Do not place any code here.
		}

		public PersistentClasses1(Session session) : base(session)
		{
			// This constructor is used when an object is loaded from a persistent storage.
			// Do not place any code here.
		}

		public override void AfterConstruction()
		{
			base.AfterConstruction();
			// Place here your initialization code.
		}
	}

}