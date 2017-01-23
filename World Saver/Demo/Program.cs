using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World_Saver;

namespace Demo {
	class Program {
		static void Main(string[ ] args) {
			var e = new World();
			e.Save( "test.txt" );
			System.Diagnostics.Process.Start( "test.txt" );
		}
	}
}
