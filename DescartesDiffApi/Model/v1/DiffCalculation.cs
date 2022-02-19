using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DescartesDiffApi.Model.v1
{
    public class DiffCalculation
    {
        // define offset and length of differences between two byte arrays
        public DiffResponse diffResponse(byte[] data1, byte[] data2)
        {
            DiffResponse diffResponse = new DiffResponse();
            List<PositionDifference> differences = new List<PositionDifference>();
            List<OffSetLength> offsetLengths = new List<OffSetLength>();
            string resultType = "";

            // if byte arrays are of same length
            if (Buffer.ByteLength(data1) == Buffer.ByteLength(data2))
            {
                // define position and difference in PositionDifference class
                foreach (var item in data1.Select((value, i) => new { i, value }))
                {
                    var index = item.i;
                    var value1 = item.value;

                    var value2 = data2[index];

                    PositionDifference valueDifference = new PositionDifference();
                    valueDifference.Position = index;

                    // define if position is ifferent
                    if (value1 == value2)
                    {
                        valueDifference.IsDifferent = false;
                    }
                    else if (value1 != value2)
                    {
                        valueDifference.IsDifferent = true;
                    }

                    // add current state to list of PositionDifference
                    differences.Add(valueDifference);
                }

                OffSetLength offSetLength = new OffSetLength();

                // initially start with assumption that previous falue was not different
                bool previousWasDifferent = false;

                // define offset and length for difference between two bytearrays
                foreach (var valueDifference in differences)
                {
                    // if value is different and previous value was not different, add to list with length 1
                    if (valueDifference.IsDifferent && !previousWasDifferent)
                    {
                        offSetLength = new OffSetLength();
                        offSetLength.OffSet = valueDifference.Position;
                        offSetLength.Length = 1;

                        previousWasDifferent = true;

                        offsetLengths.Add(offSetLength);
                    }
                    // if value is different and previous value was also different, increment length
                    else if (valueDifference.IsDifferent && previousWasDifferent)
                    {
                        offSetLength.Length = offSetLength.Length + 1;
                    }
                    // if value is not different, do nothing but set previous value as not different
                    else if (!valueDifference.IsDifferent)
                    {
                        previousWasDifferent = false;
                    }
                }
            }
                
            // if arrays are of different byte length, return SizeDoesNotMatch result
            if (Buffer.ByteLength(data1) != Buffer.ByteLength(data2))
            {
                resultType = "SizeDoesNotMatch";
            } 
            // if defined offset has no records, return Equals result
            else if (offsetLengths.Count == 0)
            {
                resultType = "Equals";
            }
            // if arrays are not of different byte length and defined offset has records, return ContentDoesNotMatch result
            else
            {
                resultType = "ContentDoesNotMatch";
            }

            diffResponse.diffs = offsetLengths;
            diffResponse.diffResultType = resultType;
            return diffResponse;
         }
    }

    // define position and difference for each byte inside array 
    public class PositionDifference
    {
        public int Position { get; set; }
        public bool IsDifferent { get; set; }
    }

    // define offset and length for each index
    public class OffSetLength
    {
        public int OffSet { get; set; }
        public int Length { get; set; }
    }

    // define Json diff response 
    public class DiffResponse
    {
        public string diffResultType { get; set; }
        public List<OffSetLength> diffs { get; set; }
    }
}