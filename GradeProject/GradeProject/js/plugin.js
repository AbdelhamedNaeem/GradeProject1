$(document).ready(function(){
"use strict";
$("html").niceScroll({
  cursorcolor: "#46c0e5",
  cursorwidth:"6px",
  cursorborder:"1px solid aquamarine",
cursorborderradius:"10%",
});
var scrollUp=$("#scroll-top");
   $(window).scroll(function(){
     "use strict";
    $(window).scrollTop()>= $(window).height() ? scrollUp.fadeIn(500) :scrollUp.fadeOut(500);
   });
    scrollUp.click(function()
    {
      "use strict";
    	$("html,body").animate({scrollTop:0},600);
    });
});
$(function(){
"use strict";
var winH = $(window).height();
$('.back, .overlay, section ').height(winH);
});
