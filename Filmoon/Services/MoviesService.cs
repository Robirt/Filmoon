using Filmoon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filmoon.Repository;
namespace Filmoon.Services
{
    public class MoviesService
    {
        private MoviesRepository MoviesRepository { get; }
        public async Task<MovieEntity> GetById(int id)
        {
            return await MoviesRepository.GetById(id);
        }

        public async Task<List<MovieEntity>> GetByName()
        {
            return await MoviesRepository.GetByName();
        }
        public async Task<MovieEntity> AddAsync(MovieEntity movie)
        {
            return await MoviesRepository.AddAsync(movie);
        }
    }
}
