using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursoSwitcher.Commons
{

    public class RequestStatusConstantsList
    {
        public const string APROBADA = "Aprobada";
        public const string ERROR = "Error";
        public const string RECHAZADA = "Rechazada";
        public const string PROCESANDO = "Procesando";
        public const string PENDIENTE = "Pendiente";
        public const string CANCELADO = "Cancelado";

        public List<SelectListItem> GenerateSelectListStatus()
        {
            List<string> Data = new List<string>() {
                APROBADA,
                ERROR,
                RECHAZADA,
                PENDIENTE,
                PROCESANDO,
                CANCELADO
            };

            List<SelectListItem> StatusList = new List<SelectListItem>();
            foreach (var value in Data)
            {
                SelectListItem item = new SelectListItem();
                item.Text = value;
                item.Value = value;
                StatusList.Add(item);
            }
            return StatusList;
        }
    }
}
