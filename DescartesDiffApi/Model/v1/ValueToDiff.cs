using System;
using System.Linq;
using System.Threading.Tasks;

namespace DescartesDiffApi.Model.v1
{
    // Class defines table ValueToDiffs in SQLite
    public class ValueToDiff
    {
        // primary key, auto-increment
        public int Id { get; set; }
        // value ID to insert and check data for directions
        public int ValueId { get; set; }
        // right or left
        public string Direction { get; set; }
        // Base64 data
        public byte[] Data { get; set; }
    }
}