﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RaspberryBackend
{
    /// <summary>
    /// Software representation of the RaspberryPi. It contains all component representations which are phyisical connected to the Rpi. 
    /// </summary>
    public class RaspberryPi
    {
        private static readonly RaspberryPi _instance = new RaspberryPi();
        private GPIOinterface _gpioInterface;
        private LCD _lcdDisplay;
        private Potentiometer _potentiometer;
        private int maxCharLCD = 16;
        private Boolean _initialized = false;

        public static RaspberryPi Instance
        {
            get { return _instance; }
        }

        private RaspberryPi() { }

        /// <summary>
        /// Default initialization of the Raspberry Pi. 
        /// Note: It initializes only one time once the gpioInterface is initialized. 
        /// </summary>
        public void initialize()
        {
            _gpioInterface = new GPIOinterface();
            _lcdDisplay = new LCD();
            _potentiometer = new Potentiometer();

            _gpioInterface.initPins();
            _lcdDisplay.initiateLCD();
            _initialized = true;
        }

        /// <summary>
        /// Resets the single instance of the Raspberry PI representation. For now it is used for Testing. 
        /// </summary>
        public void reset()
        {
            _gpioInterface = null;
            _lcdDisplay = null;
            _potentiometer = null;
        }

        /// <summary>
        /// Set the potentiometer to a value from 0000 0000 - 0111 1111
        /// </summary>
        /// <param name="data"></param>
        public void setHIPower(byte[] data)
        {
            _potentiometer.write(data);
        }

        /// <summary>
        /// Print string to LCD display
        /// </summary>
        /// <param name="s"></param>
        public void writeToLCD(string s)
        {
            _lcdDisplay.clrscr();
            _lcdDisplay.prints(s);
        }

        /// <summary>
        /// Print two lines to LCD
        /// </summary>
        /// <param name="s"></param>
        public void writeToLCDTwoLines(string s)
        {
            _lcdDisplay.printInTwoLines(s, maxCharLCD);
        }

        /// <summary>
        /// Reset the LCD (clear it's screen)
        /// </summary>
        public void resetLCD()
        {
            _lcdDisplay.clrscr();
        }

        /// <summary>
        /// Set state for background in LCD. Will want to switch to toggle
        /// </summary>
        /// <param name="targetState"></param>
        public void setLCDBackgroundState(byte targetState)
        {
            _lcdDisplay.backLight = targetState;
            _lcdDisplay.write(targetState, 1);
        }

        /// <summary>
        /// Set GPIO pin to 1
        /// </summary>
        /// <param name="id"></param>
        public void activatePin(UInt16 id)
        {
            _gpioInterface.setToOutput(id);
            _gpioInterface.writePin(id, 1);
        }

        /// <summary>
        /// Reset GPIO pin by settting to 0
        /// </summary>
        /// <param name="id"></param>
        public void deactivatePin(UInt16 id)
        {
            _gpioInterface.setToOutput(id);
            _gpioInterface.writePin(id, 0);
        }

        /// <summary>
        /// Read pin from GPIOInterface
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string readPin(UInt16 id)
        {
            //_gpioInterface.setToInput(id);
            return _gpioInterface.readPin(id);
        }

        /// <summary>
        /// Return whether raspberrypi or it's hardware components are initialized
        /// </summary>
        /// <returns></returns>
        public Boolean isInitialized()
        {
            return _initialized & _gpioInterface.isInitialized() & _lcdDisplay.isInitialized() & _potentiometer.isInitialized();
        }
    }
}
