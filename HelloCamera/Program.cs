using System;
using System.IO;
using System.Collections;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace HelloCamera
{
    public partial class Program
    {
        int index = 0;
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            // Initialize event handlers here.
            button.ButtonPressed += new Button.ButtonEventHandler(button_ButtonPressed);
            camera.PictureCaptured += new Camera.PictureCapturedEventHandler(camera_PictureCaptured);
            
            // Do one-time tasks here
            Debug.Print("Program Started");
        }
            
        void camera_PictureCaptured(Camera sender, GT.Picture picture)
        {
            string pathfilename = "\\SD\\BARCODE\\image" + index.ToString() + ".bmp";
            index++;

            sdCard.StorageDevice.WriteFile(pathfilename, picture.PictureData);

            Debug.Print("Picture Saved.");
        }
            
        void button_ButtonPressed(Button sender, Button.ButtonState state)
        {
            camera.TakePicture();
            Debug.Print("Picture Captured.");
        }
    }
}
