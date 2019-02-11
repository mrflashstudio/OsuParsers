using System;
using System.Collections.Generic;
using System.Text;
using OsuParsers.Test.Helpers;

namespace OsuParsers.Test
{
    public class BaseTest
    {
        protected virtual string RootPath => "Sample/";

        protected bool CompareTwoObjects(object object1, object object2)
        {
            return CompareHelper.CompareWithJsonFormat(object1, object2);
        }
    }
}
