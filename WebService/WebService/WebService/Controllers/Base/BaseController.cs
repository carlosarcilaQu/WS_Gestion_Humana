﻿using BlazorServer.DataAccess.Models.BaseEntity;
using Business.Interfaces.BaseBLL;
using DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers.Base
{
    [Authorize]
    public class BaseController<TModeloRequest, TModeloResponse, TEntidad, PK> : ControllerBase
        where TModeloRequest : new()
        where TModeloResponse : new()
        where TEntidad : BaseEntity<PK>, new()
    {
        private readonly IBaseBLL<TModeloRequest, TModeloResponse, TEntidad, PK> _bll;

        public BaseController(IBaseBLL<TModeloRequest, TModeloResponse, TEntidad, PK> bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bll.GetAll();
            if (result.Codigo == 200)
            {
                GenericResponse<IEnumerable<TModeloResponse>> GenericResponse = result;
                return Ok(GenericResponse);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getbyid(PK id)
        {
            var result = await _bll.getbyid(id);
            if (result.Codigo == 200)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Modify(TModeloRequest modeloModificado)
        {
            var result = await _bll.Modify(modeloModificado);
            if (result.Codigo == 200)
                return Ok(result);
            return BadRequest(result);

        }

        [HttpPost]
        public async Task<IActionResult> Insert(TModeloRequest modelo)
        {
            var result = await _bll.Insert(modelo);
            if (result.Codigo == 200)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
