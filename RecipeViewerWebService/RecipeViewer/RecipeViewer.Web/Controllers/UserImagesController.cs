﻿using RecipeViewer.Data;
using System;
using System.IO;
using System.Web;
using System.Web.Http;

namespace RecipeViewer.Web.Controllers
{
    public class UserImagesController : ApiController
    {
         private IRecipeViewerData data;

        public UserImagesController()
            : this(new RecipeViewerData())
        {
        }

        public UserImagesController(IRecipeViewerData data)
        {
            this.data = data;
        }

        public IHttpActionResult getImage(int id)
        {
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult addImageForUser()
        {
            var task = this.Request.Content.ReadAsStreamAsync();
            task.Wait();
            Stream requestStream = task.Result;

            try
            {
                Stream fileStream = File.Create(HttpContext.Current.Server.MapPath("~/" + "test.png"));
                requestStream.CopyTo(fileStream);
                fileStream.Close();
                requestStream.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Error when retrieving the image from the request! - {0}", e.Message);
            }

            //HttpResponseMessage response = new HttpResponseMessage();
            //response.StatusCode = HttpStatusCode.Created;
            //return response;
            //UserImage userImage = new UserImage();
            //var currentUserId = this.userIdProvider.GetUserId();
            var userId = User.Identity.IsAuthenticated;
            //userImage.ImageUrl = "dadasd.dadasd";

            //this.data.UserImages.Add(userImage);
            //this.data.SaveChanges();

            return Ok();
        }
    }

    public class UserImagee
    {
        public string Image { get; set; }
    }
}
