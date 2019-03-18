using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public static class ExtensionFormulario
    {
        public static void CallLoad(this Form Formulario)
        {
            var property = Formulario.GetType().GetProperty("Events", BindingFlags.GetProperty |
                        BindingFlags.Public | BindingFlags.NonPublic |
                        BindingFlags.Instance);

            var field = typeof(Form).GetField("EVENT_LOAD", BindingFlags.Static | BindingFlags.NonPublic);
            if (property != null && field != null)
            {
                EventHandlerList list = property.GetValue(Formulario, null) as EventHandlerList;
                var valor = field.GetValue(Formulario);

                var handler = list[valor] as EventHandler;
                if (handler != null)
                {
                    handler(Formulario, new System.EventArgs());
                }

            }


        }
    }
}
