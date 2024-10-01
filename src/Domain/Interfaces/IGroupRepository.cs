﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGroupRepository : IRepositoryBase<Group>
    {
        void Create(System.Text.RegularExpressions.Group group);
    }
}
