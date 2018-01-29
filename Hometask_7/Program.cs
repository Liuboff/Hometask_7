using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Hometask_7
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BlogContext db = new BlogContext())
            {
                int i = 1;
                int j = 1;
                /*
                //створення
                Blog blog1 = new Blog { Title = "Short blog", BloggerName = "BloggerBoy" };
                Blog blog2 = new Blog { Title = "Long story", BloggerName = "BloggerGirl" };
                db.Blogs.Add(blog1);
                db.Blogs.Add(blog2);
                //db.SaveChanges();
                Post p1 = new Post { Title = "Learning", DateCreated = DateTime.Now, Content = "Some long text", Blog = blog2 };
                Post p2 = new Post { Title = "Notice", DateCreated = DateTime.Now, Content = "Short text", Blog = blog1 };
                Post p3 = new Post { Title = "Fairy tail", DateCreated = DateTime.Now, Content = "True story", Blog = blog2 };
                db.Posts.AddRange(new List<Post> { p1, p2, p3 });
                db.SaveChanges();
                */
                /*
                // вывод 
                foreach (Post p in db.Posts.Include(p => p.Blog))
                    Console.WriteLine("{0} - {1}", p.Title, p.Blog.Title);
                Console.WriteLine();

                foreach (Blog t in db.Blogs.Include(t => t.Posts))
                {
                    Console.WriteLine("Blog: {0}", t.Title);
                    foreach (Post pl in t.Posts)
                    {
                        Console.WriteLine("{0} - {1} - {2}, {3}", pl.Title, pl.Content, pl.DateCreated, pl.Blog);
                    }
                    Console.WriteLine();
                }
                */


                Console.WriteLine("Обрати: перегляд таблиць - 1; CRUD операції - 2");
                string choiceStr = Console.ReadLine();
                int choice = Convert.ToInt32(choiceStr);

                if (choice == 1)
                {
                    Console.WriteLine("Обрати: Posts - 1; Blogs - 2; Posts in Blogs - 3 ");
                    string choiceTableStr = Console.ReadLine();
                    int choiceTable = Convert.ToInt32(choiceTableStr);
                    switch (choiceTable)
                    {
                        case 1:
                            foreach (Post p in db.Posts.Include(p => p.Blog))
                                Console.WriteLine("{0} - {1}", p.Title, p.Blog.Title);
                            Console.WriteLine();
                            break;

                        case 2:
                            foreach (Blog t in db.Blogs.Include(t => t.Posts))
                            {
                                Console.WriteLine("Blog: {0}", t.Title);
                            }
                            Console.WriteLine();
                            break;
                        case 3:
                            foreach (Blog t in db.Blogs.Include(t => t.Posts))
                            {
                                Console.WriteLine("Blog: {0}", t.Title);
                                foreach (Post pl in t.Posts)
                                {
                                    Console.WriteLine("{0} - {1} - {2}, {3}", pl.Title, pl.Content, pl.DateCreated, pl.Blog);
                                }
                                Console.WriteLine();
                            }
                            break;
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine(
                        "Choose operation: Create post- 1, Create blog- 2, Update post- 3, Update blog- 4, Delete post- 5, Delete blog- 6");
                    string operationStr = Console.ReadLine();
                    int choiceOperation = Convert.ToInt32(operationStr);

                    switch (choiceOperation)
                    {
                        case 1:
                            Console.WriteLine("Enter Post Title");
                            string TitleP = Console.ReadLine();
                            
                            Console.WriteLine("Enter Content");
                            string Content = Console.ReadLine();

                            Console.WriteLine("Enter Blog Id");
                            string Blog1 = Console.ReadLine();
                            int Blog = Convert.ToInt32(Blog1);

                            db.Posts.Add(new Post()
                            {
                                Id = i,
                                Title = TitleP,
                                Content = Content,
                                DateCreated = DateTime.Now,
                                BlogId = Blog
                            });
                            db.SaveChanges();
                            i++;
                            break;

                        case 2:
                            Console.WriteLine("Enter Blog Title");
                            string TitleB = Console.ReadLine();

                            Console.WriteLine("Enter Bloger name");
                            string BloggerName = Console.ReadLine();

                            db.Blogs.Add(new Blog()
                            {
                                Id = j,
                                Title = TitleB,
                                BloggerName = BloggerName
                            });
                            db.SaveChanges();
                            j++;
                            break;

                        case 3:
                            Console.WriteLine("Look on posts and after Enter Id post to update");

                            foreach (var post in db.Posts)
                            {
                                Console.WriteLine("{0} - {1}", post.Id, post.Title);
                                Console.WriteLine();
                            }

                            Console.WriteLine("Enter Id post to update:");
                            string upPostIdStr = Console.ReadLine();
                            int upPostId = Convert.ToInt32(upPostIdStr);

                            foreach (var post in db.Posts)
                            {
                                if (upPostId == post.Id)
                                {
                                    Console.WriteLine("Enter Post Title");
                                    string upTitleP = Console.ReadLine();

                                    Console.WriteLine("Enter Content");
                                    string upContent = Console.ReadLine();

                                    post.Title = upTitleP;
                                    post.Content = upContent;

                                    db.Entry(post).State = EntityState.Modified;
                                }
                            }
                            db.SaveChanges();
                            break;

                        case 4:
                            Console.WriteLine("Look on blogs and ufter Enter Id blog to update");

                            foreach (var blog in db.Blogs)
                            {
                                Console.WriteLine("{0} - {1}", blog.Id, blog.Title);
                                Console.WriteLine();
                            }

                            Console.WriteLine("Enter Id blog to update:");
                            string upBlogIdStr = Console.ReadLine();
                            int upBlogId = Convert.ToInt32(upBlogIdStr);

                            foreach (var blog in db.Blogs)
                            {
                                if (upBlogId == blog.Id)
                                {
                                    Console.WriteLine("Enter blog Title:");
                                    string upTitleB = Console.ReadLine();

                                    Console.WriteLine("Enter BloggerName:");
                                    string upBloggerName = Console.ReadLine();

                                    blog.Title = upTitleB;
                                    blog.BloggerName = upBloggerName;

                                    db.Entry(blog).State = EntityState.Modified;
                                }
                            }
                            db.SaveChanges();
                            break;

                        case 5:
                            Console.WriteLine("Enter title of post to remove:");
                            string delPostStr = Console.ReadLine();
                            Post p_toDelete = db.Posts.First(p => p.Title == delPostStr);
                            db.Posts.Remove(p_toDelete);
                            db.SaveChanges();

                            //Console.WriteLine("Enter Id post to remove:");
                            //string delPostIdStr = Console.ReadLine();
                            //int delPostId = Convert.ToInt32(delPostIdStr);
                            //foreach (var post in db.Posts)
                            //{
                            //    if (delPostId == post.Id)
                            //    {
                            //        Post post1 = db.Posts.Find(post.Id);
                            //        db.Posts.Remove(post);
                            //    }
                            //}
                            //db.SaveChanges();
                            break;

                        case 6:
                            Console.WriteLine("Enter Id blog to remove:");
                            string delBlogIdStr = Console.ReadLine();
                            int delBlogId = Convert.ToInt32(delBlogIdStr);

                            foreach (var blog in db.Blogs)
                            {
                                if (delBlogId == blog.Id)
                                {
                                    Blog blog1 = db.Blogs.Find(blog.Id);
                                    db.Blogs.Remove(blog);
                                }
                            }
                            db.SaveChanges();
                            break;

                        default: Console.WriteLine("It is wrong number");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("It is wrong number");
                }
            }
            Console.WriteLine("The end");
            Console.ReadLine();
        }
    }
}
