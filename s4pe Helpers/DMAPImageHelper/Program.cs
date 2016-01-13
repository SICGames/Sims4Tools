/***************************************************************************
 *  Copyright (C) 2016 by Sims4Tools Team                                       *
 *  kz005@bucknell.edu                                                     *
 *                                                                         *
 *  This file is part of the Sims 4 Package Interface (s4pi)               *
 *                                                                         *
 *  s4pi is free software: you can redistribute it and/or modify           *
 *  it under the terms of the GNU General Public License as published by   *
 *  the Free Software Foundation, either version 3 of the License, or      *
 *  (at your option) any later version.                                    *
 *                                                                         *
 *  s3pi is distributed in the hope that it will be useful,                *
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of         *
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the          *
 *  GNU General Public License for more details.                           *
 *                                                                         *
 *  You should have received a copy of the GNU General Public License      *
 *  along with s4pi.  If not, see <http://www.gnu.org/licenses/>.          *
 ***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using s4pi.Helpers;
using System.IO;
using System.Drawing;
using CASPartResource;

namespace DMAPImageHelper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
           if(args.Contains("/export"))
           {
               using (FileStream fs = new FileStream(args[1], FileMode.Open))
               {
                   using (SaveFileDialog save = new SaveFileDialog() { Filter = "Bitmap|*.bmp" })
                   {
                       if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                       {
                           using (FileStream fs2 = new FileStream(save.FileName, FileMode.Create))
                           {
                               DeformerMapResource dmap = new DeformerMapResource(1, fs);
                               MemoryStream ms = (MemoryStream)dmap.ToBitMap(DeformerMapResource.OutputType.Skin);
                               ms.Position = 0;
                               ms.CopyTo(fs2);
                           }
                       }
                   }
               }
           }
           if (args.Contains("/exportRobe"))
           {
               using (FileStream fs = new FileStream(args[1], FileMode.Open))
               {
                   using (SaveFileDialog save = new SaveFileDialog() { Filter = "Bitmap|*.bmp" })
                   {
                       if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                       {
                           using (FileStream fs2 = new FileStream(save.FileName, FileMode.Create))
                           {
                               DeformerMapResource dmap = new DeformerMapResource(1, fs);
                               MemoryStream ms = (MemoryStream)dmap.ToBitMap(DeformerMapResource.OutputType.Robe);
                               ms.Position = 0;
                               ms.CopyTo(fs2);
                           }
                       }
                   }
               }
           }
        }
    }
}