using Filmoon.Entities;
using Filmoon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmoon.Services
{
    public class MoviesService
    {
        private MoviesRepository MoviesRepository { get; }
        public async Task<MovieEntity> GetById(int id)
        {
            return await MoviesRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(MovieEntity movie)
        {
            await MoviesRepository.AddAsync(movie);
        }
    }
}
