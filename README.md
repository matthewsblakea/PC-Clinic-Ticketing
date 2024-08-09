# PC Clinic Ticketing

PC Clinic is a fictional company that performs repairs and consultations for clients for their PCs and other technology needs. Services include hardware repair/replacement, software and OS fixes, and consultations, with options for in-shop work, site visits, and remote support. I made it up to create an IT ticketing system as an exercise.
In the absence of any actual business activites the app is a straightforward CRUD application using SQLite, entity framework core, and a blazor front-end.

I found blazor extremely difficult to work with and the only reason I chose it was because at the time it seemed like a more attractive option than learning javascript and all the related business to make the front-end.
I found myself woefully unprepared for developing a front-end, even in C# which we had used throughout class, and blazor's all-around weirdness only made it worse. Time and again I ran into issues where it seemed like things should work and they simply wouldn't,
and I don't think all of that was due to my inexperience in web development.

The way the program is supposed to operate is the api/program layer manages the data using entity framework and sqlite with a blazor interface. However, in the time I had and using my best research, I was not able to figure out how to get aspects of blazor to cooperate with me or figure them out.
The only http requests I could get to work were GET requests but trying all I could think of and the methods outlined in the research I did, I was not able to pass any parameters into them. I know what I need to look at next regarding passing parameters into blazor components but at time of writing
the deadline for the project is coming up very soon and I know I will not have time to ship a functional application by then.

I'm sure that anyone looking at the project files who knows more than me will be able to point out something I missed or an easy way to implement the things I could not, but
that is just the learning process. It is usually painful before it is fruitful. Even with the lack of a functional product, I feel that this course and this project have taught me so many things in such a short time. Even with what I feel are currently insufficient skills, I have learned so much more
than what I knew at the outset of the class, or even what I thought I would learn.