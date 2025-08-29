export const getNonEditableMapProps = (options = {}) => {
  return {
    dragging: !options.disableDragging,
    scrollWheelZoom: !options.disableScrollZoom,
    doubleClickZoom: !options.disableDoubleClickZoom,
    touchZoom: !options.disableTouchZoom,
    boxZoom: !options.disableBoxZoom,
    keyboard: !options.disableKeyboard,
    zoomControl: !options.zoomControl,
  };
};