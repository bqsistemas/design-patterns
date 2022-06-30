using Business.Enums;
using Business.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class Movie
    {
        public string Name { get; }
        public DateTime ReleaseDate { get; }
        public MpaaRating MpaaRating { get; }
        public string Gender { get; }
        public double Rating { get; }

        public bool IsSuitableForChildren()
        {
            return MpaaRating <= MpaaRating.PG;
        }

        public bool HasCDVersion()
        {
            return ReleaseDate <= DateTime.Now.AddMonths(-6);
        }
    }
}
