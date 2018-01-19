using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ESTTest
{
    public class BackgroundSlidePanel : Grid
    {
        private Canvas _canvas;

        public int SlideDuration { get; set; }

        public BackgroundSlidePanel()
        {
            _canvas = new Canvas();
            Children.Add(_canvas);
        }

        public void Slide(Brush oldBrush, Brush newBrush)
        {
            if (newBrush.Equals(oldBrush) || !IsLoaded)
            {
                return;
            }

            ScaleTransform transform = new ScaleTransform();
            _canvas.RenderTransform = transform;

            var animation = new DoubleAnimation(0, TimeSpan.FromMilliseconds(SlideDuration));
            animation.Completed += (_, e) =>
            {
                _canvas.Background = newBrush;
                _canvas.Width = ActualWidth;
            };

            transform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property.Name.Equals(nameof(Background)))
            {
                var oldBrush = (Brush)e.OldValue;
                var newBrush = (Brush)e.NewValue;

                if (_canvas.Background == null)
                {
                    _canvas.Background = newBrush;
                }

                Slide(oldBrush, newBrush);
            }
        }
    }
}
