﻿using System.Collections.Generic;

namespace TestDemo.Isolation
{
    public interface IDao
    {
        IEnumerable<DTO> Query();
        IEnumerable<DTO> QueryCondition(QueryCondition condition);
        IEnumerable<DTO> QueryCondition(IEnumerable<int> condition);
    }

    public class DaoImpl : IDao
    {
        public IEnumerable<DTO> Query() { throw new System.NotImplementedException(); }
        public IEnumerable<DTO> QueryCondition(QueryCondition condition) { throw new System.NotImplementedException(); }
        public IEnumerable<DTO> QueryCondition(IEnumerable<int> condition) { throw new System.NotImplementedException(); }
    }
}