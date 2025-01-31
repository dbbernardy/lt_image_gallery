# ltImageGallery

# C# ASP.NET Core MVC application with a front-facing album/photo gallery that calls an external API to retrieve albums/photos with header authentication.

## Features
- Display list of albums
  - Photos from each album can be viewed in either a grid or slide view
  - The slide view does not have prev/next toggles. There was a CORS error from the server housing the images preventing this with the bootstrap markup I was using. It will auto-slide though.
- Search images by title or URL
  - Searches all photos in all albums with a photo title or url that contains the search string
- Secure API with header authentication based on instructions
- API endpoints for retrieving albums and photos
- Responsive UI with Bootstrap 5
- I was not able to add any automated tests. I kept getting an error when trying to install the Microsoft.aspnetcore.mvc.testing package

## Notes
- I decided to write this in the latest version of .net core, even though that isn't my strongest framework. I don't get the opportunity to branch out like this in my day to day operations, so I wanted to take advantage of the opportunity. Hopefully, it's up to par :)
  - This may be partly why I couldn't get automated tests implemented. Hopefully that isn't a big concern. I tried several ways to implement that, but came up short.

## Installation

git clone https://github.com/dbbernardy/lt_image_gallery

To run, either:
  1. Run via IIS Express in Visual Studio. This will load the Home->Index view and default to a list of albums.
  2. Create a site on your local IIS, add a host entry and run via any browser.
