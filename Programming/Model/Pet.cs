using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DTamachi_wpf.Programming.Model;
using DTamachi_wpf.Programming.CoreCostily;
using System.Windows.Media;

namespace DTamachi_wpf.Programming.Model
{
    class Pet
    {
        AnimationHolder aniHold = new AnimationHolder();
        public PetModel model;// = new PetModel();
        PetMoving mov = new PetMoving();
        Grid grid;
        Image petSprite;
        Image cloud;
        Cloud cModel;
        bool success = false;
        PetWindow infoWindow;

        Anima das = new Anima();


        
        //дефаулт
        public Pet(Grid grid)
        {
            model = new PetModel();
            this.grid = grid;
            petSprite = new Image();
            cloud = new Image();
            cModel = new Cloud(model, cloud);
            cloud.VerticalAlignment = VerticalAlignment.Top;
            cloud.HorizontalAlignment = HorizontalAlignment.Left;
            
            grid.Children.Add(cloud);
            

            petSprite.Width = model.width;
            petSprite.Height = model.height;
            petSprite.SnapsToDevicePixels = true;


            petSprite.VerticalAlignment = VerticalAlignment.Top;
            petSprite.HorizontalAlignment = HorizontalAlignment.Left;
            
            grid.Children.Add(petSprite);

            
            petSprite.MouseLeftButtonDown += new MouseButtonEventHandler(drag_Pet1);
            petSprite.MouseRightButtonUp += new MouseButtonEventHandler(image_Click);

            Thickness margin = petSprite.Margin;
            margin.Left = 200;
            margin.Top = 900;
            //margin.Top = 400;
            petSprite.Margin = margin;

            das = aniHold.idle;

            //this.nameInfo = nameInfo;

            //petSprite.Source;
        }

        //загрузка
        public Pet(Grid grid, LoadData ld)
        {
            model = new PetModel(ld);
            this.grid = grid;
            petSprite = new Image();
            cloud = new Image();
            cModel = new Cloud(model, cloud);
            cloud.VerticalAlignment = VerticalAlignment.Top;
            cloud.HorizontalAlignment = HorizontalAlignment.Left;

            grid.Children.Add(cloud);


            petSprite.Width = model.width;
            petSprite.Height = model.height;
            petSprite.SnapsToDevicePixels = true;


            petSprite.VerticalAlignment = VerticalAlignment.Top;
            petSprite.HorizontalAlignment = HorizontalAlignment.Left;

            grid.Children.Add(petSprite);


            petSprite.MouseLeftButtonDown += new MouseButtonEventHandler(drag_Pet1);
            petSprite.MouseRightButtonUp += new MouseButtonEventHandler(image_Click);

            Thickness margin = petSprite.Margin;
            margin.Left = 200;
            margin.Top = 900;
            //margin.Top = 400;
            petSprite.Margin = margin;

            das = aniHold.idle;

            //this.nameInfo = nameInfo;

            //petSprite.Source;
        }

        public Image getSprite()
        {
            return petSprite;
        }
        int ticks=0;
        public void Update()
        {
            //вызывается 1000/60 раз в секунду


            /*сохранение*/
            if (ticks<=60)
            {
                ticks++;
            
            }
            else
            {
                save();
                ticks = 0;
            }



            if (MouseStorage.capt)
            {
                Point pointToScreen = MouseStorage.currentMousePos;
                /*Thickness margin = petSprite.Margin;
                margin.Left = pointToScreen.X - model.xOffset;
                margin.Top = pointToScreen.Y - model.yOffset;
                petSprite.Margin = margin;

                model.cords.setX((int)margin.Left);
                model.cords.setY((int)margin.Top);*/
                setCords( (float) pointToScreen.X, (float)pointToScreen.Y);
            }

            doState();

            model.hunger += 0.0001f;
            model.clean -= 0.00005f;
            if (model.clean >= 50)
            {
                model.happines += 0.01f;
            }
            else
            {
                model.happines -= 0.01f;
            }
            if (model.hunger<= 50)
            {
                model.happines += 0.01f;
            }
            else
            {
                model.happines -= 0.01f;
            }

            petSprite.Source = das.getNext();
            model.setSize(das.getSize());
            petSprite.Width = model.width;
            petSprite.Height = model.height;

            if (model.clean<0){model.clean = 0;}
            if (model.clean>100){ model.clean = 100;}
            if (model.happines<0){ model.happines = 0;}
            if (model.happines>100){ model.happines = 100;}
            if (model.hunger < 0) { model.hunger= 0; }
            if (model.hunger > 100) { model.hunger= 100; }


            /*
            * обработка перемещения 
            */


            if (SystemParameters.WorkArea.Height - model.Y + model.height > model.height)
            {

                if (!MouseStorage.capt)
                {
                    model.verticalVelocity += 0.7f;

                    model.Y += model.verticalVelocity;

                    if (SystemParameters.WorkArea.Height - model.Y + model.height < model.height)
                    {
                        model.verticalVelocity = 0f;
                        if (idleAc==IdleAction.Fall)
                        {
                            model.state = PetModel.State.Idle;
                            idleAc = IdleAction.Sit;
                            model.ticksToFinish = (60 * 2);
                            model.phase = PetModel.Phase.Process;
                            das = aniHold.idle;
                        }

                        while (SystemParameters.WorkArea.Height - model.Y + model.height < model.height)
                        {
                            model.Y-=0.1f;
                        }
                        model.Y += 1;
                    }
                }
                else
                {
                    model.verticalVelocity = 0f;
                }

                
            }



            setOffset();
            setPosition();

            cModel.Update();
            cModel.getCloud();

            
                
            
            
            if (infoWindow!=null){infoWindow.Update();}
        }

        private void save()
        {

            string[] lines = {
                model.Name,
                model.level.ToString(),
                model.exp.ToString(),
                model.happines.ToString(),
                model.hunger.ToString(),
                model.clean.ToString(),
                model.strength.ToString(),
                model.perception.ToString(),
                model.endurance.ToString(),
                model.intellect.ToString()
            };
            System.IO.File.WriteAllLines(@"save.sav", lines);

        }

        private Coords count(Coords center, Point mouse)
        {

            Coords toRet = new Coords();
            toRet.setX((int)(-center.getX() + mouse.X));
            toRet.setY((int)(-center.getY() + mouse.Y));

            return toRet;
        }


        public void setOffset()
        {
            model.offsetX = (int) petSprite.Width/2;
            model.offsetY = (int) petSprite.Height;
        }
        public void setCords(float x, float y)
        {
            model.X = x;
            model.Y = y;
        }
        public void setPosition()
        {
            Thickness margin = petSprite.Margin;
            int xoff;
            int yoff;

            if (MouseStorage.capt)
            {
                xoff = model.mxOffset;
                yoff = model.myOffset;
            }
            else
            {
                xoff = model.offsetX;
                yoff = model.offsetY;
            }
            model.curX = (int)model.X;
            model.curY = (int)model.Y;
            margin.Left = model.curX - xoff;
            margin.Top = model.curY - yoff;

            petSprite.Margin = margin;
        }



        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
        private void image_Click(object sender, System.EventArgs e)
        {
            if (infoWindow==null)
            {
                infoWindow = new PetWindow(grid, model);
            }
            else
            {
                infoWindow.Remove();
                infoWindow = null;
            }
            
        }

        

        private void drag_Pet1(object sender, MouseButtonEventArgs e)
        {
            if (MouseStorage.capt == true)
            {
                MouseStorage.capt = false;
                model.state = PetModel.State.Nothing;
            }
            else
            {
                model.mxOffset = 45; //(int) e.GetPosition( (Image) sender).X;
                model.myOffset = 45; //(int) e.GetPosition( (Image) sender).Y;
                MouseStorage.capt = true;
                model.state = PetModel.State.Carry;
            }
            
        }
        private void moveToMouse()
        {
            Point pointToScreen = MouseStorage.currentMousePos;

            Coords center = new Coords((int)model.X, (int)model.Y); //mov.getCenter(new Coords((int)model.X, (int)model.Y), model.width, model.height);
            Coords afterProc = count(center, pointToScreen);
            double angleRad = Math.Atan2(afterProc.getX(), afterProc.getY());
            double angle = ((angleRad * 180) / Math.PI);



            Thickness margin = petSprite.Margin;
            double sa = ((model.speed * -Math.Cos(DegreeToRadian(angle + 90))));
            double sad = ((model.speed * Math.Sin(DegreeToRadian(angle + 90)))); 

            //model.cords.set((int)sa,(int)sad);

            /*margin.Left += ((model.speed * -Math.Cos(DegreeToRadian(angle + 90))));
            margin.Top += ((model.speed * Math.Sin(DegreeToRadian(angle + 90))));

            petSprite.Margin = margin;*/


            //model.cords.setX((int)margin.Left);
            //model.cords.setY((int)margin.Top);

            setCords( 
                model.X + (float)sa, 
                model.Y + (float)sad);
        }



        public enum IdleAction
        {
            Sit,
            Walk,
            Fall,
            Nap
        }
        public enum Direction
        {
            Left,
            Right
        }

        IdleAction idleAc = IdleAction.Sit;
        Direction direction = Direction.Left;


        private void idle()
        {
            if (model.phase == PetModel.Phase.Beggining)
            {


                Random rnd = new Random();
                int rnum = rnd.Next(0, 100);

                if (model.verticalVelocity > 0.1f)
                {
                    idleAc = IdleAction.Fall;
                    das = aniHold.fall;
                    model.phase = PetModel.Phase.Process;
                }
                else if (rnum >=0 && rnum <= 60)
                {
                    idleAc = IdleAction.Sit;
                    das = aniHold.idle;
                    model.ticksToFinish = (60 * 4);
                }
                else if (rnum > 60 && rnum <= 80)
                {
                    idleAc = IdleAction.Nap;
                    das = aniHold.nap;
                    model.ticksToFinish = (60 * 10);
                }
                else
                {
                    
                    idleAc = IdleAction.Walk;
                    das = aniHold.walk;
                    rnum = rnd.Next(0, 200);
                    if (rnum < 100)
                    {
                        //go left
                        direction = Direction.Left;
                        petSprite.RenderTransformOrigin = new Point(0.5, 0.5);
                        ScaleTransform flipTrans = new ScaleTransform();
                        flipTrans.ScaleX = 1;
                        petSprite.RenderTransform = flipTrans;
                        rnum = rnd.Next(1, 12);
                        model.ticksToFinish = (60 * rnum);
                    }
                    else
                    {
                        //go right
                        direction = Direction.Right;
                        petSprite.RenderTransformOrigin = new Point(0.5, 0.5);
                        ScaleTransform flipTrans = new ScaleTransform();
                        flipTrans.ScaleX = -1;
                        petSprite.RenderTransform = flipTrans;
                        rnum = rnd.Next(1, 12);
                        model.ticksToFinish = (60 * rnum);
                        
                    }
                }

                das.start();
                model.phase = PetModel.Phase.Process;
            }
            else
            if (model.phase == PetModel.Phase.Process)
            {

                if (model.verticalVelocity > 0.1f)
                {
                    idleAc = IdleAction.Fall;
                    das = aniHold.fall;
                    model.phase = PetModel.Phase.Beggining;
                }

                if (model.ticksToFinish > 0)
                {
                    model.ticksToFinish--;

                    switch (idleAc)
                    {
                        case IdleAction.Sit:
                            break;
                        case IdleAction.Nap:
                            break;
                        case IdleAction.Walk:

                            switch (direction)
                            {
                                case Direction.Left:
                                    model.X -= 1;
                                    petSprite.RenderTransformOrigin = new Point(0.5, 0.5);
                                    ScaleTransform flipTrans = new ScaleTransform();
                                    flipTrans.ScaleX = 1;
                                    petSprite.RenderTransform = flipTrans;
                                    if (model.X - SystemParameters.WorkArea.Left < 100)
                                    {
                                        direction = Direction.Right;
                                    }
                                    break;
                                case Direction.Right:
                                    model.X += 1;
                                    petSprite.RenderTransformOrigin = new Point(0.5, 0.5);
                                    flipTrans = new ScaleTransform();
                                    flipTrans.ScaleX = -1;
                                    petSprite.RenderTransform = flipTrans;
                                    if (SystemParameters.WorkArea.Width - model.X < 100)
                                    {
                                        direction = Direction.Left;
                                    }
                                    break;
                                default:
                                    break;
                            }

                            break;
                        default:
                            break;
                    }



                }
                else
                {
                    model.ticksToFinish = 0;
                    //das = aniHold.idle;
                    model.phase = PetModel.Phase.Ending;
                }
            }
            else
            if (model.phase == PetModel.Phase.Ending)
            {
                model.phase = PetModel.Phase.None;
                model.state = PetModel.State.Nothing;
            }
            if (model.hunger < 0)
            {
                model.health -= 0.01f;
                model.happines -= 0.1f;
                model.hunger = 0;
            }
            if (model.clean < 0)
            {
                model.clean = 0;
            }
        }
        private void eating()
        {
            if (model.phase == PetModel.Phase.Beggining)
            {
                model.ticksToFinish = (60*3);
                das = aniHold.eat;
                das.start();
                //Thickness margin = petSprite.Margin;

                //margin.Left -= model.xOffset;
                //margin.Top += model.yOffset;

                //petSprite.Margin = margin;
                //model.setSize(das.getSize());

                model.phase = PetModel.Phase.Process;
            } else
            if (model.phase == PetModel.Phase.Process)
            {
                if (model.ticksToFinish > 0)
                {
                    model.ticksToFinish --;
                    model.hunger -= 0.04f;
                    model.clean -= 0.02f;
                    if (model.clean <= 80)
                    {
                        model.health -= 0.05f;
                    }
                    if (model.clean <= 40)
                    {
                        model.health -= 0.05f;
                    }
                }
                else
                {
                    model.ticksToFinish = 0;
                    //Thickness margin = petSprite.Margin;
                    //margin.Left += model.xOffset;
                    //margin.Top -= model.yOffset;

                    //petSprite.Margin = margin;
                    das = aniHold.idle;
                    model.phase = PetModel.Phase.Ending;
                }
            } else
            if (model.phase == PetModel.Phase.Ending)
            {
                model.exp += 10;
                model.phase = PetModel.Phase.None;
                model.state = PetModel.State.Nothing;
            }
            if (model.hunger < 0)
            {
                model.health -= 0.01f;
                model.happines -= 0.1f;
                model.hunger = 0;
            }
            if (model.clean < 0)
            {
                model.clean = 0;
            }
        }
        private void washing()
        {
            if (model.phase == PetModel.Phase.Beggining)
            {
                model.ticksToFinish = (60 * 3);
                das = aniHold.wash;
                das.start();
                model.phase = PetModel.Phase.Process;
                Console.WriteLine("start wash");
            }
            else
            if (model.phase == PetModel.Phase.Process)
            {
                if (model.ticksToFinish > 0)
                {
                    model.ticksToFinish -= 1;
                    model.clean += 0.1f;
                    Console.WriteLine("ts:"+model.ticksToFinish);
                }
                else
                {
                    model.ticksToFinish = 0;
                    das = aniHold.idle;
                    model.phase = PetModel.Phase.Ending;
                    Console.WriteLine("finish wash");
                }
            }
            else
            if (model.phase == PetModel.Phase.Ending)
            {
                model.exp += 10;
                model.phase = PetModel.Phase.None;
                model.state = PetModel.State.Nothing;
            }
            if (model.clean >= 100)
            {
                model.clean = 100;
            }
        }
        private void reading()
        {
            if (model.phase == PetModel.Phase.Beggining)
            {
                if (model.happines <= 40)
                {
                    success = false;
                    model.phase = PetModel.Phase.Ending;
                    
                }
                else
                {
                    success = true;
                    model.ticksToFinish = (60 * 10);
                    das = aniHold.read;
                    das.start();
                    model.phase = PetModel.Phase.Process;
                }
            }
            else
            if (model.phase == PetModel.Phase.Process)
            {
                if (model.ticksToFinish > 0)
                {
                    model.ticksToFinish--;
                }
                else
                {
                    model.ticksToFinish = 0;
                    das = aniHold.idle;
                    model.phase = PetModel.Phase.Ending;
                }
            }
            else
            if (model.phase == PetModel.Phase.Ending)
            {
                if (success)
                {
                    model.intellect += 5f;
                    model.happines -= 20f;
                    model.exp += 30;
                    success = false;
                    model.phase = PetModel.Phase.None;
                    model.state = PetModel.State.Nothing;
                }
                else
                {
                    model.phase = PetModel.Phase.None;
                    model.state = PetModel.State.Nothing;
                }
            }
        }
        private void dumbbell()
        {
            if (model.phase == PetModel.Phase.Beggining)
            {
                if (model.happines <= 40)
                {
                    success = false;
                    model.phase = PetModel.Phase.Ending;

                }
                else
                {
                    success = true;
                    model.ticksToFinish = (60 * 3);
                    das = aniHold.dumbbell;
                    das.start();
                    model.phase = PetModel.Phase.Process;
                }
            }
            else
            if (model.phase == PetModel.Phase.Process)
            {
                if (model.ticksToFinish > 0)
                {
                    model.ticksToFinish--;
                    model.strength += 0.01f;
                    model.endurance += 0.01f;
                    model.clean -= 0.02f;
                    model.happines -= 0.1f;
                }
                else
                {
                    model.ticksToFinish = 0;
                    das = aniHold.idle;
                    model.phase = PetModel.Phase.Ending;
                }
            }
            else
            if (model.phase == PetModel.Phase.Ending)
            {
                if (success)
                {
                    success = false;
                    model.exp += 10;
                    model.phase = PetModel.Phase.None;
                    model.state = PetModel.State.Nothing;
                }
                else
                {
                    model.phase = PetModel.Phase.None;
                    model.state = PetModel.State.Nothing;
                }
            }
        }
        private void dance()
        {
            if (model.phase == PetModel.Phase.Beggining)
            {
                model.ticksToFinish = (60 * 3);
                das = aniHold.dance;
                das.start();
                model.phase = PetModel.Phase.Process;
            }
            else
            if (model.phase == PetModel.Phase.Process)
            {
                if (model.ticksToFinish > 0)
                {
                    model.ticksToFinish--;
                    model.clean -= 0.02f;
                }
                else
                {
                    model.ticksToFinish = 0;
                    das = aniHold.idle;
                    model.phase = PetModel.Phase.Ending;
                }
            }
            else
            if (model.phase == PetModel.Phase.Ending)
            {
                model.exp += 10;
                model.phase = PetModel.Phase.None;
                model.state = PetModel.State.Nothing;
            }
            if (model.hunger < 0)
            {
                model.health -= 0.01f;
                model.happines -= 0.1f;
                model.hunger = 0;
            }
            if (model.clean < 0)
            {
                model.clean = 0;
            }
        }
        private void walk()
        {
            if (model.phase == PetModel.Phase.Beggining)
            {
                model.ticksToFinish = (60 * 2);
                das = aniHold.walk;
                das.start();
                model.phase = PetModel.Phase.Process;
            }
            else
            if (model.phase == PetModel.Phase.Process)
            {
                if (model.ticksToFinish > 0)
                {
                    model.ticksToFinish--;
                }
                else
                {
                    model.ticksToFinish = 0;
                    das = aniHold.idle;
                    model.phase = PetModel.Phase.Ending;
                }
            }
            else
            if (model.phase == PetModel.Phase.Ending)
            {
                model.phase = PetModel.Phase.None;
                model.state = PetModel.State.Nothing;
            }
            if (model.hunger < 0)
            {
                model.health -= 0.01f;
                model.happines -= 0.1f;
                model.hunger = 0;
            }
            if (model.clean < 0)
            {
                model.clean = 0;
            }
        }
        private void doState()
        {



            if (model.state == PetModel.State.Carry)
            {
                das = aniHold.carry;
            }
            else if (model.state == PetModel.State.Nothing)
            {
                //das = aniHold.idle;
                //model.setSize(das.getSize());

                if (model.movetype == PetModel.MoveType.Mouse)
                {
                    moveToMouse();
                }
                if (model.movetype == PetModel.MoveType.Stay)
                {
                    model.state = PetModel.State.Idle;
                    model.phase = PetModel.Phase.Beggining;
                    //idle();
                }
                if (model.movetype == PetModel.MoveType.Static)
                {
                    
                    //а что тут писать? на то он и статик, что стоит
                    //но если что, тут пусто
                }
            }
            else
            {
                if (model.state == PetModel.State.Idle)
                {
                    idle();
                }
                if (model.state == PetModel.State.Eating)
                {
                    eating();
                }
                if (model.state == PetModel.State.Washing)
                {
                    washing();
                }
                if (model.state == PetModel.State.Reading)
                {
                    reading();
                }
                if (model.state == PetModel.State.Dumbbell)
                {
                    dumbbell();
                }
                if (model.state == PetModel.State.Dance)
                {
                    dance();
                }
            }



        }

        
    }
}
