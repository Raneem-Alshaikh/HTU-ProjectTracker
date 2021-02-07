using FinalProject.DTO;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface ITeamLeaderRepository
    {
        public Task InsertTeamLeader(CreateUserDto projectManagerDto);
        public List<TeamLeader> GetTeamLeaders();
        public void DeleteTeamLeader(string Id);
        public TeamLeader GetTeamLeader(string teamLeaderId);
        public void EditTeamLeader(EditUserDto teamLeaderDto);
    }
}
