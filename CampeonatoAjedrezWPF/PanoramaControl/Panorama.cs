﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace PanoramaControl
{
    [TemplatePart(Name = "PART_ScrollViewer", Type = typeof(ScrollViewer))]
    public class Panorama : ItemsControl
    {
        #region Data
        private ScrollViewer sv=new ScrollViewer();
        private Point scrollTarget;
        private Point scrollStartPoint;
        private Point scrollStartOffset;
        private Point previousPoint;
        private Vector velocity;
        private double friction;
        private DispatcherTimer animationTimer = new DispatcherTimer(DispatcherPriority.DataBind);
        private static int PixelsToMoveToBeConsideredScroll = 1000;
        private static int PixelsToMoveToBeConsideredClick = 2;
        private Random rand = new Random(DateTime.Now.Millisecond);
        private bool _mouseDownFlag;
        private Cursor _savedCursor;
        #endregion

        #region Ctor
        public Panorama()
        {
            friction = 0.85;
            //OnApplyTemplate();
            animationTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            animationTimer.Tick += new EventHandler(HandleWorldTimerTick);
            animationTimer.Start();
        }

        static Panorama()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Panorama), new FrameworkPropertyMetadata(typeof(Panorama)));
        }
        #endregion

        #region Properties
        public double Friction
        {
            get { return 1.0 - friction; }
            set { friction = Math.Min(Math.Max(1.0 - value, 0), 1.0); }
        }

        public List<Brush> TileColorPair
        {
            get 
            {
                int idx = rand.Next(TileColors.Length);
                return new List<Brush>() { TileColors[idx], ComplimentaryTileColors[idx] };
            }
        }

        #region DPs


        #region ItemBox

        public static readonly DependencyProperty ItemBoxProperty =
            DependencyProperty.Register("ItemBox", typeof(double), typeof(Panorama),
                new FrameworkPropertyMetadata((double)120.0));


        public double ItemBox
        {
            get { return (double)GetValue(ItemBoxProperty); }
            set { SetValue(ItemBoxProperty, value); }
        }

        #endregion

        #region GroupHeight

        public static readonly DependencyProperty GroupHeightProperty =
            DependencyProperty.Register("GroupHeight", typeof(double), typeof(Panorama),
                new FrameworkPropertyMetadata((double)640.0));


        public double GroupHeight
        {
            get { return (double)GetValue(GroupHeightProperty); }
            set { SetValue(GroupHeightProperty, value); }
        }

        #endregion



        #region HeaderFontSize

        public static readonly DependencyProperty HeaderFontSizeProperty =
            DependencyProperty.Register("HeaderFontSize", typeof(double), typeof(Panorama),
                new FrameworkPropertyMetadata((double)30.0));

        public double HeaderFontSize
        {
            get { return (double)GetValue(HeaderFontSizeProperty); }
            set { SetValue(HeaderFontSizeProperty, value); }
        }

        #endregion


 
        #region HeaderFontColor

        public static readonly DependencyProperty HeaderFontColorProperty =
            DependencyProperty.Register("HeaderFontColor", typeof(Brush), typeof(Panorama),
                new FrameworkPropertyMetadata((Brush)Brushes.White));

        public Brush HeaderFontColor
        {
            get { return (Brush)GetValue(HeaderFontColorProperty); }
            set { SetValue(HeaderFontColorProperty, value); }
        }

        #endregion

        #region HeaderFontFamily

        public static readonly DependencyProperty HeaderFontFamilyProperty =
            DependencyProperty.Register("HeaderFontFamily", typeof(FontFamily), typeof(Panorama),
                new FrameworkPropertyMetadata((FontFamily)new FontFamily("Segoe UI")));

        public FontFamily HeaderFontFamily
        {
            get { return (FontFamily)GetValue(HeaderFontFamilyProperty); }
            set { SetValue(HeaderFontFamilyProperty, value); }
        }

        #endregion

        #region TileColors

        public static readonly DependencyProperty TileColorsProperty =
            DependencyProperty.Register("TileColors", typeof(Brush[]), typeof(Panorama),
                new FrameworkPropertyMetadata((Brush[])null));

        public Brush[] TileColors
        {
            get { return (Brush[])GetValue(TileColorsProperty); }
            set { SetValue(TileColorsProperty, value); }
        }

        #endregion

        #region ComplimentaryTileColors

        public static readonly DependencyProperty ComplimentaryTileColorsProperty =
            DependencyProperty.Register("ComplimentaryTileColors", typeof(Brush[]), typeof(Panorama),
                new FrameworkPropertyMetadata((Brush[])null));

        public Brush[] ComplimentaryTileColors
        {
            get { return (Brush[])GetValue(ComplimentaryTileColorsProperty); }
            set { SetValue(ComplimentaryTileColorsProperty, value); }
        }

        #endregion

        #region UseSnapBackScrolling

        public static readonly DependencyProperty UseSnapBackScrollingProperty =
            DependencyProperty.Register("UseSnapBackScrolling", typeof(bool), typeof(Panorama),
                new FrameworkPropertyMetadata((bool)true));

        public bool UseSnapBackScrolling
        {
            get { return (bool)GetValue(UseSnapBackScrollingProperty); }
            set { SetValue(UseSnapBackScrollingProperty, value); }
        }

        #endregion

        #endregion

        #endregion

        #region Private Methods

        private void DoStandardScrolling()
        {
            sv.ScrollToHorizontalOffset(scrollTarget.X);
            sv.ScrollToVerticalOffset(scrollTarget.Y);
            scrollTarget.X += velocity.X;
            scrollTarget.Y += velocity.Y;
            velocity *= friction;
        }


        private void HandleWorldTimerTick(object sender, EventArgs e)
        {
            var prop = DesignerProperties.IsInDesignModeProperty;
            bool isInDesignMode = (bool)DependencyPropertyDescriptor.FromProperty(prop,
                typeof(FrameworkElement)).Metadata.DefaultValue;

            if (isInDesignMode)
                return;


            if (IsMouseCaptured)
            {
                Point currentPoint = Mouse.GetPosition(this);
                velocity = previousPoint - currentPoint;
                previousPoint = currentPoint;
            }
            else
            {
                if (velocity.Length > 1)
                {
                    DoStandardScrolling();
                }
                else
                {
                    if (UseSnapBackScrolling)
                    {
                        int mx = (int)(sv).HorizontalOffset % ((int)ActualWidth == 0 ? 1 : (int)ActualWidth);
                        if (mx == 0)
                            return;
                        int ix = (int)sv.HorizontalOffset / (int)ActualWidth;
                        double snapBackX = mx > ActualWidth / 2 ? (ix + 1) * ActualWidth : ix * ActualWidth;
                        sv.ScrollToHorizontalOffset(sv.HorizontalOffset + (snapBackX - sv.HorizontalOffset) / 4.0);
                    }
                    else
                    {
                        DoStandardScrolling();
                    }
                }
            }
        }
        #endregion

        #region Overrides


        public override void OnApplyTemplate()
        {
            sv = (ScrollViewer)Template.FindName("PART_ScrollViewer", this)??new ScrollViewer();
            base.OnApplyTemplate();
        }


        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (sv.IsMouseOver)
            {
                _mouseDownFlag = true;

                // Save starting point, used later when determining how much to scroll.
                scrollStartPoint = e.GetPosition(this);
                scrollStartOffset.X = sv.HorizontalOffset;
                scrollStartOffset.Y = sv.VerticalOffset;
            }

            base.OnPreviewMouseLeftButtonDown(e);
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            if (_mouseDownFlag)
            {
                Point currentPoint = e.GetPosition(this);

                // Determine the new amount to scroll.
                Point delta = new Point(scrollStartPoint.X - currentPoint.X, scrollStartPoint.Y - currentPoint.Y);

                if (Math.Abs(delta.X) > PixelsToMoveToBeConsideredScroll ||
                    Math.Abs(delta.Y) > PixelsToMoveToBeConsideredScroll)
                {
                    scrollTarget.X = scrollStartOffset.X + delta.X;
                    scrollTarget.Y = scrollStartOffset.Y + delta.Y;

                    // Scroll to the new position.
                    sv.ScrollToHorizontalOffset(scrollTarget.X);
                    sv.ScrollToVerticalOffset(scrollTarget.Y);

                    if (!this.IsMouseCaptured)
                    {
                        if ((sv.ExtentWidth > sv.ViewportWidth) ||
                            (sv.ExtentHeight > sv.ViewportHeight))
                        {
                            _savedCursor = this.Cursor;
                            this.Cursor = Cursors.ScrollWE;
                        }

                        this.CaptureMouse();
                    }
                }
            }

            base.OnPreviewMouseMove(e);
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            bool mouseDownFlag = _mouseDownFlag;
            // mouse move events may trigger while inside this handler.
            _mouseDownFlag = false;

            if (this.IsMouseCaptured)
            {
                // scroll action stopped
                this.Cursor = _savedCursor;
                this.ReleaseMouseCapture();
            }
            else if (mouseDownFlag)
            {
                // click action stopped
            }

            _savedCursor = null;

            base.OnPreviewMouseLeftButtonUp(e);
        }
        #endregion

    }
}
