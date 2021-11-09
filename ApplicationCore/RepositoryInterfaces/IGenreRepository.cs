﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    interface IGenreRepository : IAsyncRepository<Genre>
    {
        Task<List<Genre>> GetAllGenres();
    }
}
