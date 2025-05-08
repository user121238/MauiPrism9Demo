using System.ComponentModel;

namespace UI.Behaviors
{
    public class LabelTextAnimationBehavior : Behavior<Label>
    {
        #region Overrides of Behavior<Label>

        /// <summary>
        /// Application developers override this method to implement the behaviors that will be associated with <paramref name="bindable" />.
        /// </summary>
        /// <param name="bindable">The bindable object to which the behavior was attached.</param>
        protected override void OnAttachedTo(Label bindable)
        {
            bindable.PropertyChanged += LabelPropertyChanged;
            base.OnAttachedTo(bindable);
        }


        /// <summary>
        /// Application developers override this method to remove the behaviors from <paramref name="bindable" />
        /// that were implemented in a previous call to the <see cref="M:Microsoft.Maui.Controls.Behavior`1.OnAttachedTo(`0)" /> method.
        /// </summary>
        /// <param name="bindable">The bindable object from which the behavior was detached.</param>
        protected override void OnDetachingFrom(Label bindable)
        {
            bindable.PropertyChanged -= LabelPropertyChanged;
            base.OnDetachingFrom(bindable);
        }

        private async void LabelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Label.Text) && sender is Label label && !string.IsNullOrWhiteSpace(label.Text))
            {
                label.Opacity = 0;

                await label.FadeTo(1, 250);
            }
        }

        #endregion
    }
}
