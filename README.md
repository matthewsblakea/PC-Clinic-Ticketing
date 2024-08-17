# PC Clinic Ticketing

PC Clinic is a fictional company that performs repairs and consultations for clients for their PCs and other technology needs. Services include hardware repair/replacement, software and OS fixes, and consultations, with options for in-shop work, site visits, and remote support.
I made it up to create an IT ticketing system as an exercise. In the absence of any actual business activites the app is a straightforward CRUD application using SQLite, entity framework core, and a user interface made with razorpages.
As you would expect, the API layer uses the DbContext class to perform database operations on user, device, ticket, and repairlog objects. Users include both technicians, admins, and customers, with customers having one or many devices. Each device can have work tickets.
Each ticket has a lifetime of received -> in-progress -> complete -> closed and has repairlogs for technicians to log the work they do whether it be contacting customers or performing the repair. They also log their own UserId (primary key) as another foreign key here.

It is prudent to remember that a business application like this should by necessity include authentication of some sort. However, since we were asked for this project to use SQLite specifically, it was not possible to do this as SQLite does not support authentication.
The functionality that authentication and the use of tokens would provide if possible under the constraints would be access control: technicians and admins would have different permissions. Technicians and admins would have their own portals to log in to.
Technicians would handle customer ticketing needs while admins would do the same in addition to managing technician accounts and possibly even the database itself through things like DELETE calls, which should not be exposed to technicians.
Given this I made the conscious choice to omit the usage of the password property for users and the usage of any DELETE api calls. I wanted to be clear and point this out specifically so that it does not appear that I omitted these out of ignorance or neglect.
I am very aware that in 'the real world' this aspect would be of utmost importance to a business application that is central to the business' model. It is also not the most pretty website because I had to learn web development in about a week to make this.

To run the application the "HttpClient.BaseAddress" at line 17 in program.cs of the UI project may need to be changed to the appropriate localhost number of the API project. This can be found when running the API project in swagger, which should be pre-configured.
The database is automatically created by an "ensurecreated" method in the API's program.cs at "c:\\PcClinicDb\\PcClinicDb.db". The .db file is created by this but as I found out "ensurecreated" does NOT create the PcClinicDb folder. The folder has to be made in your c: drive.
Then change start-up projects for the solution to be both the API and UI projects, and hit run.

Included in the project is a console test app (just in case), some basic unit tests to confirm that entity framework was correctly mapping foreign keys, the database itself (created at "c:\\PcClinicDb\\PcClinicDb.db" so you can delete it when you are done using it) , the program/API layer, and the razor pages UI.
The API calls are all asynchronous as they should be. An inspection of the APIs and the API calls will show the usage of asynchronically sending objects and lists of objects via JSON. Comments are included in the files to illustrate SOLID principles followed.