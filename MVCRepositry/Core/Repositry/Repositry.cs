using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repositry
{
    public class Repositry<T> : IRepositry<T> where T : class 
    {
        private readonly AppDbContext _context;
        public Repositry(AppDbContext context)
        {
            _context=context;
        }
        public async Task<T> GetAsync(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            return item;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var items= await _context.Set<T>().ToListAsync();
            return items;
        }

        public async Task<IEnumerable<T>> GetAllWithEntityAsync(params string[] args)
        {
            IQueryable<T> query = _context.Set<T>();
            if (args.Length > 0)
            {
                foreach (string arg in args)
                    query = query.Include(arg);
            }
            return query.ToList();
        }
        public T FindBy(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }

        public T FindBy(Expression<Func<T, bool>> match, params string[] args)
        {
            IQueryable<T> query = _context.Set<T>();
            if (args.Length > 0)
            {
                foreach (string arg in args)
                    query = query.Include(arg);
            }
            return query.SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, params string[] args)
        {
            IQueryable<T> query = _context.Set<T>();
            if (args.Length > 0)
            {
                foreach (string arg in args)
                    query = query.Include(arg);
            }
            return query.Where(match).ToList();
        }
        IEnumerable<T> IRepositry<T>.FindAll(Expression<Func<T, bool>> match, int skip, int take)
        {
            return _context.Set<T>().Where(match).Skip(skip).Take(take).ToList();
        }

        IEnumerable<T> IRepositry<T>.FindAll(Expression<Func<T, bool>> match, int skip, int take, params string[] args)
        {

            IQueryable<T> query = _context.Set<T>();
            if (args.Length > 0)
            {
                foreach (string arg in args)
                    query = query.Include(arg);
            }
            return query.Where(match).Skip(skip).Take(take).ToList();
        }

        IEnumerable<T> IRepositry<T>.FindAll(Expression<Func<T, bool>> match, int skip, int take, Expression<Func<T, object>> orderBy, string direction, params string[] args)
        {
            IQueryable<T> query = _context.Set<T>().Where(match);
            if (args.Length > 0)
            {
                foreach (string arg in args)
                    query = query.Include(arg);
            }
            if (direction == "ASC")
            {
                query.OrderBy(orderBy);
            }
            else
            {
                query.OrderByDescending(orderBy);
            }
            return query.Skip(skip).Take(take).ToList();
        }
        public T Add(T item)
        {
            _context.Set<T>().Add(item);    
            _context.SaveChanges();
            return item;
        }
        IEnumerable<T> AddRange(IEnumerable<T> items)
        {
            _context.Set<T>().AddRange(items);  
            _context.SaveChanges();
            return items;
        }

    }




}

