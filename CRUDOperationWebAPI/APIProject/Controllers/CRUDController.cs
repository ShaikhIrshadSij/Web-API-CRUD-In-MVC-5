using APIProject.POCO.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIProject.Controllers
{
    //[Route("api/crud")]
    public class CRUDController : ApiController
    {
        private readonly CRUDContext _context;
        public CRUDController()
        {
            _context = new CRUDContext();
        }
        [Route("api/crud/GetUsersList")]
        [HttpGet]
        public object GetUsersList()
        {
            try
            {
                var usersList = _context.Users.ToList();
                return Ok(new { data = usersList, status = true });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message, status = false });
            }
        }
        [Route("GetUsersListById")]
        [HttpGet]
        public object GetUsersListById(int userId)
        {
            try
            {
                var usersList = _context.Users.FirstOrDefault(x => x.Id == userId);
                return Ok(new { data = usersList, status = true });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message, status = false });
            }
        }
        [Route("AddUpdateUsers")]
        [HttpPost]
        public object AddUpdateUsers(string userData)
        {
            try
            {
                var user = JsonConvert.DeserializeAnonymousType(userData, new Users());
                if (user != null)
                {
                    var isUserExist = _context.Users.FirstOrDefault(x => x.Id == user.Id);
                    if (isUserExist == null)
                    {
                        _context.Users.Add(user);
                        _context.SaveChanges();
                        return Ok(new { message = "Data added successfully", status = true });
                    }
                    else
                    {
                        isUserExist.Name = user.Name;
                        isUserExist.Email = user.Email;
                        isUserExist.Password = user.Password;
                        _context.SaveChanges();
                        return Ok(new { message = "Data updated successfully", status = true });
                    }
                }
                else
                {
                    return Ok(new { message = "Something went wrong", status = false });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message, status = false });
            }
        }
        [Route("DeleteUserById")]
        [HttpDelete]
        public object DeleteUserById(int userId)
        {
            try
            {
                var usersList = _context.Users.FirstOrDefault(x => x.Id == userId);
                if (usersList != null)
                {
                    _context.Users.Remove(usersList);
                    _context.SaveChanges();
                    return Ok(new { message = "Data deleted successfully", status = true });
                }
                return Ok(new { message = "Something went wrong", status = false });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message, status = false });
            }
        }
    }
}
