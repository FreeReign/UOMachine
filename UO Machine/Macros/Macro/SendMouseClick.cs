﻿/* Copyright (C) 2009 Matthew Geyer
 * 
 * This file is part of UO Machine.
 * 
 * UO Machine is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * UO Machine is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with UO Machine.  If not, see <http://www.gnu.org/licenses/>. */

using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UOMachine.Macros
{
    public static partial class Macro
    {
        /// <summary>
        /// Send mouse click to relative position in the client window.
        /// </summary>
        /// <param name="client">Target client.</param>
        /// <param name="button">System.Windows.Forms.MouseButtons to click.</param>
        /// <param name="x">X position of point to click relative to client window's X position.</param>
        /// <param name="y">Y position of point to click relative to client window's Y position.</param>
        /// <param name="doubleClick">True for double click, false for single click.</param>
        /// <returns>True on success.</returns>
        public static bool SendMouseClick(int client, MouseButtons button, int x, int y, bool doubleClick)
        {
            ClientInfo ci;
            if (ClientInfoCollection.GetClient(client, out ci))
            {
                NativeMethods.INPUT[] inputs = new NativeMethods.INPUT[2];
                NativeMethods.MOUSEINPUT mi = new NativeMethods.MOUSEINPUT();
                inputs[0].type = NativeMethods.INPUT_MOUSE;
                inputs[1].type = NativeMethods.INPUT_MOUSE;
                mi.dx = 0;
                mi.dy = 0;
                switch (button)
                {
                    case MouseButtons.None:
                        return false;
                    case MouseButtons.Left:
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_LEFTDOWN;
                        inputs[0].mkhi.mi = mi;
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_LEFTUP;
                        inputs[1].mkhi.mi = mi;
                        break;
                    case MouseButtons.Right:
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_RIGHTDOWN;
                        inputs[0].mkhi.mi = mi;
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_RIGHTUP;
                        inputs[1].mkhi.mi = mi;
                        break;
                    case MouseButtons.Middle:
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_MIDDLEDOWN;
                        inputs[0].mkhi.mi = mi;
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_MIDDLEUP;
                        inputs[1].mkhi.mi = mi;
                        break;
                    case MouseButtons.XButton1:
                        mi.mouseData = NativeMethods.XBUTTON1;
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_XDOWN;
                        inputs[0].mkhi.mi = mi;
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_XUP;
                        inputs[1].mkhi.mi = mi;
                        break;
                    case MouseButtons.XButton2:
                        mi.mouseData = NativeMethods.XBUTTON2;
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_XDOWN;
                        inputs[0].mkhi.mi = mi;
                        mi.dwFlags = NativeMethods.MOUSEEVENTF_XUP;
                        inputs[1].mkhi.mi = mi;
                        break;
                }

                if (!ci.PrepareWindowForInput())
                {
                    ci.DetachFromWindow();
                    return false;
                }

                NativeMethods.WINDOWPLACEMENT wp = new NativeMethods.WINDOWPLACEMENT();
                if (NativeMethods.GetWindowPlacement(ci.WindowHandle, ref wp))
                {
                    /*int screenX = wp.rcNormalPosition.X + x;
                    int screenY = wp.rcNormalPosition.Y + y;
                    int absX = (screenX * 65536 / Screen.PrimaryScreen.Bounds.Width);
                    int absY = (screenY * 65536 / Screen.PrimaryScreen.Bounds.Height);
                    inputs[0].mkhi.mi.dx = absX;
                    inputs[1].mkhi.mi.dx = absX;
                    inputs[0].mkhi.mi.dy = absY;
                    inputs[1].mkhi.mi.dy = absY;*/

                    // using this method because absolute position is always off by a pixel or 2

                    if (!NativeMethods.SetCursorPos(x + wp.rcNormalPosition.X, y + wp.rcNormalPosition.Y)) return false;
                }
                else return false;

                uint success = NativeMethods.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(inputs[0]));
                if (doubleClick && success == inputs.Length)
                {
                    success = NativeMethods.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(inputs[0]));
                }
                ci.DetachFromWindow();
                return success == inputs.Length;
            }
            return false;
        }
    }
}