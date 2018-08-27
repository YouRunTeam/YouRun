using System;
using System.Collections.Generic;

namespace YouRunApp
{
    public class PriorityList
    {
        List<float> Priorities;

        public PriorityList()
        {
            Priorities = new List<float>(GlobalConstants.NUMBER_OF_PRIORITIES);
        }


    }
}
