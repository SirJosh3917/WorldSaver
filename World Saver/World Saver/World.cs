using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Saver {
	public class World {
		public World() {
			//The example to the class

			this.format = "basic_1";

			this.blist = new object[ ] {
				9,
				new object[]{ 9 },
				new object[]{ 385, "hi", 0},
				new object[]{ 242, 0, 1, 2}
			};

			this.bglist = new object[ ] {
				500
			};

			this.blocks = new int[ ][ ] {
				new int[]{ 1, 1, 1, 1, 1 },
				new int[]{ 1, 0, 0, 0, 1 },
				new int[]{ 1, 0, 0, 0, 4 },
				new int[]{ 1, 0, 3, 0, 1 },
				new int[]{ 1, 1, 1, 1, 1 }
			};

			this.backgrounds = new int[ ][ ] {
				new int[]{ 1, 1, 1, 1, 1 },
				new int[]{ 1, 1, 1, 1, 1 },
				new int[]{ 1, 1, 1, 1, 1 },
				new int[]{ 1, 1, 1, 1, 1 },
				new int[]{ 1, 1, 1, 1, 1 }
			};

			this.data = new Dictionary<string, Dictionary<string, object>>() {
					{ "bot key", new Dictionary<string, object>(){
							{ "json data", "ahdiowahdioahwiod" }
						}
					},
					{ "another bot key", new Dictionary<string, object>(){
							{ "more json data", "..." }
						}
					}
			};
		}

		/// <summary>
		/// A key to allow for possible backwards compatability, and different formats
		/// </summary>
		public string format { get; set; }

		/// <summary>
		/// A list of blocks, in the format that they would be sent to playerIO
		/// </summary>
		public object[ ] blist { get; set; }

		public object[ ] bglist { get; set; }

		public int[ ][ ] blocks { get; set; }

		public int[ ][ ] backgrounds { get; set; }

		/// <summary>
		/// Optional data table that can be used to store bot-specific data
		/// </summary>
		public Dictionary<string, Dictionary<string, object>> data { get; set; }

		public void Save(string filename) {
			JsonSerializer serializer = new JsonSerializer();
			serializer.Converters.Add( new JavaScriptDateTimeConverter() );
			serializer.NullValueHandling = NullValueHandling.Ignore;
			using (StreamWriter sw = new StreamWriter( filename ))
			using (JsonWriter writer = new JsonTextWriter( sw )) {
				serializer.Serialize( writer, this );
			}
		}
	}
}
