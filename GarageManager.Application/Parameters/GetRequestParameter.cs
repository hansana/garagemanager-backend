using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Application.Parameters
{
    public class GetRequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetRequestParameter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        public GetRequestParameter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = PageSize > 10 ? 10 : pageSize;
        }
    }
}
