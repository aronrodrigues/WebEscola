using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace WebEscola.Helpers
{
    public static class MeusHelpers
    {
        public static string TextoTrucadoFor<TModel, TValue>(
                this HtmlHelper<TModel> htmlHelper, 
                Expression<Func<TModel, TValue>> expression, 
                int tamanho)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var value = metadata.Model;
            if ( value.ToString().Length <= tamanho)
            {
                return value.ToString();
            }
            else
            {
                return value.ToString().Substring(0, tamanho) + "...";
            }
        }

    }
}
