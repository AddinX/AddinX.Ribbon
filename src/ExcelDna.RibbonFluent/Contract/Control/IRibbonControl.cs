using System;
using AddinX.Ribbon.Contract.Command;

namespace AddinX.Ribbon.Contract.Control {
    public interface IRibbonId<out T> {
        T Id(string name);

        T IdMso(string name);

        T IdQ(string ns, string name);
    }

    public interface IRibbonIdQ<out T> {
        T Id(string name);

        T IdQ(string ns, string name);
    }

    public interface IRibbonItemId<out T> {
        T Id(string name);
    }

    public interface IRibbonImage<out T> {
        /// <summary>
        /// ImageMso
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T ImageMso(string name);

        T ImagePath(string path);

        T NoImage();
    }

    public interface IRibbonSize<out T> {
        /// <summary>
        /// 大型尺寸
        /// </summary>
        /// <returns></returns>
        T LargeSize();

        /// <summary>
        /// 普通大小
        /// </summary>
        /// <returns></returns>
        T NormalSize();
    }

    public interface IRibbonLabel<out T> {
        /// <summary>
        /// 显示标签
        /// </summary>
        /// <returns></returns>
        T ShowLabel();

        /// <summary>
        /// 隐藏标签
        /// </summary>
        /// <returns></returns>
        T HideLabel();
    }

    public interface IRibbonKeytip<out T> {
        T Keytip(string keytip);
    }

    public interface IRibbonExtra<out T> : IRibbonKeytip<T> {
        // T Description(string description);

        T Supertip(string supertip);

        T Screentip(string screentip);
    }

    public interface IRibbonSupertip<out T> {
        T Supertip(string supertip);

        T Screentip(string screentip);
    }

    public interface IRibbonGalleryExtra<out T> : IRibbonExtra<T> {
        T SizeString(int size);

        T ItemHeight(int height);

        T ItemWidth(int width);

        T NumberRows(int rows);

        T NumberColumns(int cols);
    }

    public interface IRibbonListExtra<out T> : IRibbonExtra<T> {
        T MaxLength(int maxLength);

        T SizeString(int size);
    }

    public interface IRibbonStyle<out T> {
        T HorizontalDisplay();

        T VerticalDisplay();
    }

    public interface IRibbonItems<out T, out TItems> {
        T Items(Action<TItems> builder);
    }

    public interface IRibbonDynamic<out T, out TItems> : IRibbonItems<T, TItems> {
        T DynamicItems();
    }

    public interface IRibbonItemImage<out T> {
        T ShowItemImage();

        T HideItemImage();
    }

    public interface IRibbonItemLabel<out T> {
        T ShowItemLabel();

        T HideItemLabel();
    }

    public interface IRibbonItemSize<out T> {
        T ItemNormalSize();

        T ItemLargeSize();
    }

    /// <summary>
    /// Ribbon callback 标记
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCommand"></typeparam>
    public interface IRibbonCallback<TCommand> where TCommand : ICommand {
        void Callback(Action<TCommand> builder);

        void Callback(TCommand command);
    }
}