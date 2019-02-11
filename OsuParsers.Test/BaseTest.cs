using System;
using System.Collections.Generic;
using System.Text;
using OsuParsers.Test.Helpers;

namespace OsuParsers.Test
{
    public class BaseTest
    {
        public virtual string RootPath => "Sample/";

        public bool CompareTwoObjects(object object1, object object2)
        {
            return CompareHelper.CompareWithJsonFormat(object1, object2);
        }
    }
}
