using CORE.DTOs;
using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface IPrendaEstampadoServicio
    {
        Task<Confirmacion<ICollection<PrendaEstampadoDTOconID>>> GetPrendaEstampado();
        Task<Confirmacion<PrendaEstampadoDTOconID>> PostPrendaEstampado(PrendaEstampadoDTO PrendaEstampadoDTO);
        Task<Confirmacion<PrendaEstampado>> DeletePrendaEstampado(int ID);
        Task<Confirmacion<PrendaEstampadoDTO>> PutPrendaEstampado(int ID, PrendaEstampadoDTO PrendaEstampadoDTO);
    }
}
