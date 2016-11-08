using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltersWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace FiltersWebApp.Filters
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var result = context.Result as ObjectResult;
            if (result != null)
            {
                var o = result;
                context.Result = new JsonResult(new ActionResultWrapper {Results = JsonConvert.SerializeObject(o.Value)});
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var result = context.Result;
        }
    }
}
