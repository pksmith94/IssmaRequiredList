﻿using IssmaRequiredList.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Services
{
    public class MovementService
    {
        //Create
        public async Task<bool> CreateMovementAsync(Movement model)
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                if (model == null)
                    return false;
                else
                {
                    con.Movements.Add(model);
                    return await con.SaveChangesAsync() == 1;
                }
            }
        }
        //Read
        public async Task<Movement> GetMovementByIdAsync(int id)
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                var entity = await con.Movements.FindAsync(id);
                if (entity == null)
                    throw new InvalidOperationException();
                else
                    return entity;
            }
        }
        public async Task<IEnumerable<Movement>> GetAllMovementsAsync()
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                return await con.Movements.ToListAsync();
            }
        }
        //Update
        public async Task<bool> UpdateMovement(Movement model)
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                var currentModel = await con.Movements.FindAsync(model.MovementId);

                if (currentModel == null)
                    return false;
                else
                {
                    currentModel.MovementNumber = model.MovementNumber;
                    currentModel.PieceId = model.PieceId;

                    return await con.SaveChangesAsync() == 1;
                }
            }
        }
        //Delete
        public async Task<bool> DeleteMovementById(int id)
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                var entity = await con.Movements.FindAsync(id);
                if (entity == null)
                    throw new InvalidOperationException();
                else
                {
                    con.Movements.Remove(entity);
                    return await con.SaveChangesAsync() == 1;
                }

            }
        }
    }
}
