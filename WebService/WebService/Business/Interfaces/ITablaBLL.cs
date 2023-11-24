using Business.Interfaces.BaseBLL;
using DataAccess.Models;
using DTO.Request;
using DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ITablaBLL : IBaseBLL<TablaRequest, TablaResponse, Tabla, long>
    {
    }
}
