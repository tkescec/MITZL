/*
Template Name: Color Admin - Responsive Admin Dashboard Template build with Bootstrap 5
Version: 5.1.3
Author: Sean Ngu
Website: http://www.seantheme.com/color-admin/
	----------------------------
		APPS CONTENT TABLE
	----------------------------

	<!-- ======== GLOBAL SCRIPT SETTING ======== -->
	01. Handle Fixed Header Option
	02. Handle Tooltip & Popover Activation
	03. Handle Theme Panel Expand
	04. Handle Theme Page Control
	05. Handle Payment Type Selection
	06. Handle Checkout Qty Control
	07. Handle Product Image
	08. Handle Paroller
	09. Handle Check Bootstrap Version
	10. Handle Get Css Variable

	<!-- ======== APPLICATION SETTING ======== -->
	Application Controller
*/

var app = {
	font: {
	
	},
	color: {
	
	}
}


/* 01. Handle Fixed Header Option
------------------------------------------------ */
var handleHeaderFixedTop = function() {
	if ($('#header[data-fixed-top="true"]').length !== 0) {
		var targetScrollTop = $('#top-nav').height();
		var targetPaddingTop = $('#header').height();
		$(window).on('scroll', function() {
			if ($(window).scrollTop() >= targetScrollTop) {
				$('body').css('padding-top', targetPaddingTop);
				$('#header').addClass('header-fixed');
			} else {
				$('#header').removeClass('header-fixed');
				$('body').css('padding-top', '0');
			}
		});
	}
};


/* 02. Handle Tooltip & Popover Activation
------------------------------------------------ */
var handleTooltipPopoverActivation = function() {
	if ($('[data-bs-toggle=tooltip]').length !== 0) {
		$('[data-bs-toggle=tooltip]').tooltip();
	}
	if ($('[data-bs-toggle=popover]').length !== 0) {
		$('[data-bs-toggle=popover]').popover();
	}
};


/* 03. Handle Theme Panel Expand
------------------------------------------------ */
var handleThemePanelExpand = function() {
	$(document).on('click', '[data-click="theme-panel-expand"]', function() {
		var targetContainer = '.theme-panel';
		var targetClass = 'active';
		if ($(targetContainer).hasClass(targetClass)) {
			$(targetContainer).removeClass(targetClass);
		} else {
			$(targetContainer).addClass(targetClass);
		}
	});
};


/* 04. Handle Theme Page Control
------------------------------------------------ */
var handleThemePageControl = function() {
	if (typeof Cookies !== 'undefined') {
		$(document).on('click', '.theme-list [data-theme]', function(e) {	
			e.preventDefault();
			var targetThemeClass = $(this).attr('data-theme');
		
			for (var x = 0; x < document.body.classList.length; x++) {
				var targetClass = document.body.classList[x];
				if (targetClass.search('theme-') > -1) {
					$('body').removeClass(targetClass);
				}
			}
		
			$('body').addClass(targetThemeClass);
			$('.theme-list [data-theme]').not(this).closest('li').removeClass('active');
			$(this).closest('li').addClass('active');
		
			if (Cookies) {
				Cookies.set('theme', $(this).attr('data-theme'));
				$(document).trigger('theme-change');
			}
		});
		
		$(document).on('change', '.theme-panel [name="app-theme-dark-mode"]', function() {
			var targetCookie = '';
		
			if ($(this).is(':checked')) {
				$('html').addClass('dark-mode');
				targetCookie = 'dark-mode';
			} else {
				$('html').removeClass('dark-mode');
			}
		
			if (Cookies) {
				App.initVariable();
				Cookies.set('app-theme-dark-mode', targetCookie);
				$(document).trigger('theme-change');
			}
		});
		
		if (Cookies.get('theme') && $('.theme-list').length !== 0) {
			var targetElm = '.theme-list [data-theme="'+ Cookies.get('theme') +'"]';
			$(targetElm).trigger('click');
		}
		if (Cookies.get('app-theme-dark-mode') && $('.theme-panel [name="app-theme-dark-mode"]').length !== 0) {
			$('.theme-panel [name="app-theme-dark-mode"]').prop('checked', true).trigger('change');
		}
	}
};


/* 05. Handle Payment Type Selection
------------------------------------------------ */
var handlePaymentTypeSelection = function() {
	$(document).on('click', '[data-click="set-payment"]', function(e) {
		e.preventDefault();
		var targetLi = $(this).closest('li');
		var targetValue = $(this).attr('data-value');
		
		$('[data-click="set-payment"]').closest('li').not(targetLi).removeClass('active');
		$('[data-id="payment-type"]').val(targetValue);
		$(targetLi).addClass('active');
	});
};


/* 06. Handle Checkout Qty Control
------------------------------------------------ */
var handleQtyControl = function() {
	$(document).on('click', '[data-click="increase-qty"]', function(e) {
		e.preventDefault();
		var targetInput = $(this).attr('data-target');
		var targetValue = parseInt($(targetInput).val()) + 1;  
		
		$(targetInput).val(targetValue);
	});
	$('[data-click="decrease-qty"]').click(function(e) {
		e.preventDefault();
		var targetInput = $(this).attr('data-target');
		var targetValue = parseInt($(targetInput).val()) - 1;  
		    targetValue = (targetValue < 0) ? 0 : targetValue;
		
		$(targetInput).val(targetValue);
	});
};


/* 07. Handle Product Image
------------------------------------------------ */
var handleProductImage = function() {
	$(document).on('click', '[data-click="show-main-image"]', function(e) {
		e.preventDefault();

		var targetContainer = '[data-id="main-image"]';
		var targetImage = '<img src="'+ $(this).attr('data-url') +'" />';
		var targetLi = $(this).closest('li');

		$(targetContainer).html(targetImage);
		$(targetLi).addClass('active');
		$('[data-click="show-main-image"]').closest('li').not(targetLi).removeClass('active');
	});
};


/* 08. Handle Paroller
------------------------------------------------ */
var handleParoller = function() {
	if (typeof $.fn.paroller !== 'undefined') {
		if ($('[data-paroller="true"]').length !== 0) {
			$('[data-paroller="true"]').paroller();
		}
	}
};


/* 09. Handle Check Bootstrap Version
------------------------------------------------ */
var handleCheckBootstrapVersion = function() {
	return parseInt($.fn.tooltip.Constructor.VERSION);
};


/* 10. Handle Get Css Variable
------------------------------------------------ */
var getCssVariable = function(variable) {
	return window.getComputedStyle(document.body).getPropertyValue(variable).trim();
};


/* Application Controller
------------------------------------------------ */
var App = function () {
	"use strict";
	
	return {
		//main function
		init: function () {
			handleHeaderFixedTop();
			handleTooltipPopoverActivation();
			handleThemePanelExpand();
			handleThemePageControl();
			handlePaymentTypeSelection();
			handleQtyControl();
			handleProductImage();
			handleParoller();
			
			this.initVariable();
		},
		initVariable: function() {
			app.color.theme          = getCssVariable('--app-theme');
			app.font.family          = getCssVariable('--bs-body-font-family');
			app.font.size            = getCssVariable('--bs-body-font-size');
			app.font.weight          = getCssVariable('--bs-body-font-weight');
			app.color.componentColor = getCssVariable('--app-component-color');
			app.color.componentBg    = getCssVariable('--app-component-bg');
			app.color.dark           = getCssVariable('--bs-dark');
			app.color.light          = getCssVariable('--bs-light');
			app.color.blue           = getCssVariable('--bs-blue');
			app.color.indigo         = getCssVariable('--bs-indigo');
			app.color.purple         = getCssVariable('--bs-purple');
			app.color.pink           = getCssVariable('--bs-pink');
			app.color.red            = getCssVariable('--bs-red');
			app.color.orange         = getCssVariable('--bs-orange');
			app.color.yellow         = getCssVariable('--bs-yellow');
			app.color.green          = getCssVariable('--bs-green');
			app.color.success        = getCssVariable('--bs-success');
			app.color.teal           = getCssVariable('--bs-teal');
			app.color.cyan           = getCssVariable('--bs-cyan');
			app.color.white          = getCssVariable('--bs-white');
			app.color.gray           = getCssVariable('--bs-gray');
			app.color.lime           = getCssVariable('--bs-lime');
			app.color.gray100        = getCssVariable('--bs-gray-100');
			app.color.gray200        = getCssVariable('--bs-gray-200');
			app.color.gray300        = getCssVariable('--bs-gray-300');
			app.color.gray400        = getCssVariable('--bs-gray-400');
			app.color.gray500        = getCssVariable('--bs-gray-500');
			app.color.gray600        = getCssVariable('--bs-gray-600');
			app.color.gray700        = getCssVariable('--bs-gray-700');
			app.color.gray800        = getCssVariable('--bs-gray-800');
			app.color.gray900        = getCssVariable('--bs-gray-900');
			app.color.black          = getCssVariable('--bs-black');
			
			app.color.themeRgb          = getCssVariable('--app-theme-rgb');
			app.font.familyRgb          = getCssVariable('--bs-body-font-family-rgb');
			app.font.sizeRgb            = getCssVariable('--bs-body-font-size-rgb');
			app.font.weightRgb          = getCssVariable('--bs-body-font-weight-rgb');
			app.color.componentColorRgb = getCssVariable('--app-component-color-rgb');
			app.color.componentBgRgb    = getCssVariable('--app-component-bg-rgb');
			app.color.darkRgb           = getCssVariable('--bs-dark-rgb');
			app.color.lightRgb          = getCssVariable('--bs-light-rgb');
			app.color.blueRgb           = getCssVariable('--bs-blue-rgb');
			app.color.indigoRgb         = getCssVariable('--bs-indigo-rgb');
			app.color.purpleRgb         = getCssVariable('--bs-purple-rgb');
			app.color.pinkRgb           = getCssVariable('--bs-pink-rgb');
			app.color.redRgb            = getCssVariable('--bs-red-rgb');
			app.color.orangeRgb         = getCssVariable('--bs-orange-rgb');
			app.color.yellowRgb         = getCssVariable('--bs-yellow-rgb');
			app.color.greenRgb          = getCssVariable('--bs-green-rgb');
			app.color.successRgb        = getCssVariable('--bs-success-rgb');
			app.color.tealRgb           = getCssVariable('--bs-teal-rgb');
			app.color.cyanRgb           = getCssVariable('--bs-cyan-rgb');
			app.color.whiteRgb          = getCssVariable('--bs-white-rgb');
			app.color.grayRgb           = getCssVariable('--bs-gray-rgb');
			app.color.limeRgb           = getCssVariable('--bs-lime-rgb');
			app.color.gray100Rgb        = getCssVariable('--bs-gray-100-rgb');
			app.color.gray200Rgb        = getCssVariable('--bs-gray-200-rgb');
			app.color.gray300Rgb        = getCssVariable('--bs-gray-300-rgb');
			app.color.gray400Rgb        = getCssVariable('--bs-gray-400-rgb');
			app.color.gray500Rgb        = getCssVariable('--bs-gray-500-rgb');
			app.color.gray600Rgb        = getCssVariable('--bs-gray-600-rgb');
			app.color.gray700Rgb        = getCssVariable('--bs-gray-700-rgb');
			app.color.gray800Rgb        = getCssVariable('--bs-gray-800-rgb');
			app.color.gray900Rgb        = getCssVariable('--bs-gray-900-rgb');
			app.color.blackRgb          = getCssVariable('--bs-black-rgb');
		}
	};
}();

$(document).ready(function() {
	App.init();
});
//# sourceMappingURL=data:application/json;charset=utf8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImFwcC5qcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSIsImZpbGUiOiJhcHAubWluLmpzIiwic291cmNlc0NvbnRlbnQiOlsiLypcclxuVGVtcGxhdGUgTmFtZTogQ29sb3IgQWRtaW4gLSBSZXNwb25zaXZlIEFkbWluIERhc2hib2FyZCBUZW1wbGF0ZSBidWlsZCB3aXRoIEJvb3RzdHJhcCA1XHJcblZlcnNpb246IDUuMS4zXHJcbkF1dGhvcjogU2VhbiBOZ3VcclxuV2Vic2l0ZTogaHR0cDovL3d3dy5zZWFudGhlbWUuY29tL2NvbG9yLWFkbWluL1xyXG5cdC0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS1cclxuXHRcdEFQUFMgQ09OVEVOVCBUQUJMRVxyXG5cdC0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS1cclxuXHJcblx0PCEtLSA9PT09PT09PSBHTE9CQUwgU0NSSVBUIFNFVFRJTkcgPT09PT09PT0gLS0+XHJcblx0MDEuIEhhbmRsZSBGaXhlZCBIZWFkZXIgT3B0aW9uXHJcblx0MDIuIEhhbmRsZSBUb29sdGlwICYgUG9wb3ZlciBBY3RpdmF0aW9uXHJcblx0MDMuIEhhbmRsZSBUaGVtZSBQYW5lbCBFeHBhbmRcclxuXHQwNC4gSGFuZGxlIFRoZW1lIFBhZ2UgQ29udHJvbFxyXG5cdDA1LiBIYW5kbGUgUGF5bWVudCBUeXBlIFNlbGVjdGlvblxyXG5cdDA2LiBIYW5kbGUgQ2hlY2tvdXQgUXR5IENvbnRyb2xcclxuXHQwNy4gSGFuZGxlIFByb2R1Y3QgSW1hZ2VcclxuXHQwOC4gSGFuZGxlIFBhcm9sbGVyXHJcblx0MDkuIEhhbmRsZSBDaGVjayBCb290c3RyYXAgVmVyc2lvblxyXG5cdDEwLiBIYW5kbGUgR2V0IENzcyBWYXJpYWJsZVxyXG5cclxuXHQ8IS0tID09PT09PT09IEFQUExJQ0FUSU9OIFNFVFRJTkcgPT09PT09PT0gLS0+XHJcblx0QXBwbGljYXRpb24gQ29udHJvbGxlclxyXG4qL1xyXG5cclxudmFyIGFwcCA9IHtcclxuXHRmb250OiB7XHJcblx0XHJcblx0fSxcclxuXHRjb2xvcjoge1xyXG5cdFxyXG5cdH1cclxufVxyXG5cclxuXHJcbi8qIDAxLiBIYW5kbGUgRml4ZWQgSGVhZGVyIE9wdGlvblxyXG4tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0gKi9cclxudmFyIGhhbmRsZUhlYWRlckZpeGVkVG9wID0gZnVuY3Rpb24oKSB7XHJcblx0aWYgKCQoJyNoZWFkZXJbZGF0YS1maXhlZC10b3A9XCJ0cnVlXCJdJykubGVuZ3RoICE9PSAwKSB7XHJcblx0XHR2YXIgdGFyZ2V0U2Nyb2xsVG9wID0gJCgnI3RvcC1uYXYnKS5oZWlnaHQoKTtcclxuXHRcdHZhciB0YXJnZXRQYWRkaW5nVG9wID0gJCgnI2hlYWRlcicpLmhlaWdodCgpO1xyXG5cdFx0JCh3aW5kb3cpLm9uKCdzY3JvbGwnLCBmdW5jdGlvbigpIHtcclxuXHRcdFx0aWYgKCQod2luZG93KS5zY3JvbGxUb3AoKSA+PSB0YXJnZXRTY3JvbGxUb3ApIHtcclxuXHRcdFx0XHQkKCdib2R5JykuY3NzKCdwYWRkaW5nLXRvcCcsIHRhcmdldFBhZGRpbmdUb3ApO1xyXG5cdFx0XHRcdCQoJyNoZWFkZXInKS5hZGRDbGFzcygnaGVhZGVyLWZpeGVkJyk7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0JCgnI2hlYWRlcicpLnJlbW92ZUNsYXNzKCdoZWFkZXItZml4ZWQnKTtcclxuXHRcdFx0XHQkKCdib2R5JykuY3NzKCdwYWRkaW5nLXRvcCcsICcwJyk7XHJcblx0XHRcdH1cclxuXHRcdH0pO1xyXG5cdH1cclxufTtcclxuXHJcblxyXG4vKiAwMi4gSGFuZGxlIFRvb2x0aXAgJiBQb3BvdmVyIEFjdGl2YXRpb25cclxuLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tICovXHJcbnZhciBoYW5kbGVUb29sdGlwUG9wb3ZlckFjdGl2YXRpb24gPSBmdW5jdGlvbigpIHtcclxuXHRpZiAoJCgnW2RhdGEtYnMtdG9nZ2xlPXRvb2x0aXBdJykubGVuZ3RoICE9PSAwKSB7XHJcblx0XHQkKCdbZGF0YS1icy10b2dnbGU9dG9vbHRpcF0nKS50b29sdGlwKCk7XHJcblx0fVxyXG5cdGlmICgkKCdbZGF0YS1icy10b2dnbGU9cG9wb3Zlcl0nKS5sZW5ndGggIT09IDApIHtcclxuXHRcdCQoJ1tkYXRhLWJzLXRvZ2dsZT1wb3BvdmVyXScpLnBvcG92ZXIoKTtcclxuXHR9XHJcbn07XHJcblxyXG5cclxuLyogMDMuIEhhbmRsZSBUaGVtZSBQYW5lbCBFeHBhbmRcclxuLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tICovXHJcbnZhciBoYW5kbGVUaGVtZVBhbmVsRXhwYW5kID0gZnVuY3Rpb24oKSB7XHJcblx0JChkb2N1bWVudCkub24oJ2NsaWNrJywgJ1tkYXRhLWNsaWNrPVwidGhlbWUtcGFuZWwtZXhwYW5kXCJdJywgZnVuY3Rpb24oKSB7XHJcblx0XHR2YXIgdGFyZ2V0Q29udGFpbmVyID0gJy50aGVtZS1wYW5lbCc7XHJcblx0XHR2YXIgdGFyZ2V0Q2xhc3MgPSAnYWN0aXZlJztcclxuXHRcdGlmICgkKHRhcmdldENvbnRhaW5lcikuaGFzQ2xhc3ModGFyZ2V0Q2xhc3MpKSB7XHJcblx0XHRcdCQodGFyZ2V0Q29udGFpbmVyKS5yZW1vdmVDbGFzcyh0YXJnZXRDbGFzcyk7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHQkKHRhcmdldENvbnRhaW5lcikuYWRkQ2xhc3ModGFyZ2V0Q2xhc3MpO1xyXG5cdFx0fVxyXG5cdH0pO1xyXG59O1xyXG5cclxuXHJcbi8qIDA0LiBIYW5kbGUgVGhlbWUgUGFnZSBDb250cm9sXHJcbi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLSAqL1xyXG52YXIgaGFuZGxlVGhlbWVQYWdlQ29udHJvbCA9IGZ1bmN0aW9uKCkge1xyXG5cdGlmICh0eXBlb2YgQ29va2llcyAhPT0gJ3VuZGVmaW5lZCcpIHtcclxuXHRcdCQoZG9jdW1lbnQpLm9uKCdjbGljaycsICcudGhlbWUtbGlzdCBbZGF0YS10aGVtZV0nLCBmdW5jdGlvbihlKSB7XHRcclxuXHRcdFx0ZS5wcmV2ZW50RGVmYXVsdCgpO1xyXG5cdFx0XHR2YXIgdGFyZ2V0VGhlbWVDbGFzcyA9ICQodGhpcykuYXR0cignZGF0YS10aGVtZScpO1xyXG5cdFx0XHJcblx0XHRcdGZvciAodmFyIHggPSAwOyB4IDwgZG9jdW1lbnQuYm9keS5jbGFzc0xpc3QubGVuZ3RoOyB4KyspIHtcclxuXHRcdFx0XHR2YXIgdGFyZ2V0Q2xhc3MgPSBkb2N1bWVudC5ib2R5LmNsYXNzTGlzdFt4XTtcclxuXHRcdFx0XHRpZiAodGFyZ2V0Q2xhc3Muc2VhcmNoKCd0aGVtZS0nKSA+IC0xKSB7XHJcblx0XHRcdFx0XHQkKCdib2R5JykucmVtb3ZlQ2xhc3ModGFyZ2V0Q2xhc3MpO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0fVxyXG5cdFx0XHJcblx0XHRcdCQoJ2JvZHknKS5hZGRDbGFzcyh0YXJnZXRUaGVtZUNsYXNzKTtcclxuXHRcdFx0JCgnLnRoZW1lLWxpc3QgW2RhdGEtdGhlbWVdJykubm90KHRoaXMpLmNsb3Nlc3QoJ2xpJykucmVtb3ZlQ2xhc3MoJ2FjdGl2ZScpO1xyXG5cdFx0XHQkKHRoaXMpLmNsb3Nlc3QoJ2xpJykuYWRkQ2xhc3MoJ2FjdGl2ZScpO1xyXG5cdFx0XHJcblx0XHRcdGlmIChDb29raWVzKSB7XHJcblx0XHRcdFx0Q29va2llcy5zZXQoJ3RoZW1lJywgJCh0aGlzKS5hdHRyKCdkYXRhLXRoZW1lJykpO1xyXG5cdFx0XHRcdCQoZG9jdW1lbnQpLnRyaWdnZXIoJ3RoZW1lLWNoYW5nZScpO1xyXG5cdFx0XHR9XHJcblx0XHR9KTtcclxuXHRcdFxyXG5cdFx0JChkb2N1bWVudCkub24oJ2NoYW5nZScsICcudGhlbWUtcGFuZWwgW25hbWU9XCJhcHAtdGhlbWUtZGFyay1tb2RlXCJdJywgZnVuY3Rpb24oKSB7XHJcblx0XHRcdHZhciB0YXJnZXRDb29raWUgPSAnJztcclxuXHRcdFxyXG5cdFx0XHRpZiAoJCh0aGlzKS5pcygnOmNoZWNrZWQnKSkge1xyXG5cdFx0XHRcdCQoJ2h0bWwnKS5hZGRDbGFzcygnZGFyay1tb2RlJyk7XHJcblx0XHRcdFx0dGFyZ2V0Q29va2llID0gJ2RhcmstbW9kZSc7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0JCgnaHRtbCcpLnJlbW92ZUNsYXNzKCdkYXJrLW1vZGUnKTtcclxuXHRcdFx0fVxyXG5cdFx0XHJcblx0XHRcdGlmIChDb29raWVzKSB7XHJcblx0XHRcdFx0QXBwLmluaXRWYXJpYWJsZSgpO1xyXG5cdFx0XHRcdENvb2tpZXMuc2V0KCdhcHAtdGhlbWUtZGFyay1tb2RlJywgdGFyZ2V0Q29va2llKTtcclxuXHRcdFx0XHQkKGRvY3VtZW50KS50cmlnZ2VyKCd0aGVtZS1jaGFuZ2UnKTtcclxuXHRcdFx0fVxyXG5cdFx0fSk7XHJcblx0XHRcclxuXHRcdGlmIChDb29raWVzLmdldCgndGhlbWUnKSAmJiAkKCcudGhlbWUtbGlzdCcpLmxlbmd0aCAhPT0gMCkge1xyXG5cdFx0XHR2YXIgdGFyZ2V0RWxtID0gJy50aGVtZS1saXN0IFtkYXRhLXRoZW1lPVwiJysgQ29va2llcy5nZXQoJ3RoZW1lJykgKydcIl0nO1xyXG5cdFx0XHQkKHRhcmdldEVsbSkudHJpZ2dlcignY2xpY2snKTtcclxuXHRcdH1cclxuXHRcdGlmIChDb29raWVzLmdldCgnYXBwLXRoZW1lLWRhcmstbW9kZScpICYmICQoJy50aGVtZS1wYW5lbCBbbmFtZT1cImFwcC10aGVtZS1kYXJrLW1vZGVcIl0nKS5sZW5ndGggIT09IDApIHtcclxuXHRcdFx0JCgnLnRoZW1lLXBhbmVsIFtuYW1lPVwiYXBwLXRoZW1lLWRhcmstbW9kZVwiXScpLnByb3AoJ2NoZWNrZWQnLCB0cnVlKS50cmlnZ2VyKCdjaGFuZ2UnKTtcclxuXHRcdH1cclxuXHR9XHJcbn07XHJcblxyXG5cclxuLyogMDUuIEhhbmRsZSBQYXltZW50IFR5cGUgU2VsZWN0aW9uXHJcbi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLSAqL1xyXG52YXIgaGFuZGxlUGF5bWVudFR5cGVTZWxlY3Rpb24gPSBmdW5jdGlvbigpIHtcclxuXHQkKGRvY3VtZW50KS5vbignY2xpY2snLCAnW2RhdGEtY2xpY2s9XCJzZXQtcGF5bWVudFwiXScsIGZ1bmN0aW9uKGUpIHtcclxuXHRcdGUucHJldmVudERlZmF1bHQoKTtcclxuXHRcdHZhciB0YXJnZXRMaSA9ICQodGhpcykuY2xvc2VzdCgnbGknKTtcclxuXHRcdHZhciB0YXJnZXRWYWx1ZSA9ICQodGhpcykuYXR0cignZGF0YS12YWx1ZScpO1xyXG5cdFx0XHJcblx0XHQkKCdbZGF0YS1jbGljaz1cInNldC1wYXltZW50XCJdJykuY2xvc2VzdCgnbGknKS5ub3QodGFyZ2V0TGkpLnJlbW92ZUNsYXNzKCdhY3RpdmUnKTtcclxuXHRcdCQoJ1tkYXRhLWlkPVwicGF5bWVudC10eXBlXCJdJykudmFsKHRhcmdldFZhbHVlKTtcclxuXHRcdCQodGFyZ2V0TGkpLmFkZENsYXNzKCdhY3RpdmUnKTtcclxuXHR9KTtcclxufTtcclxuXHJcblxyXG4vKiAwNi4gSGFuZGxlIENoZWNrb3V0IFF0eSBDb250cm9sXHJcbi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLSAqL1xyXG52YXIgaGFuZGxlUXR5Q29udHJvbCA9IGZ1bmN0aW9uKCkge1xyXG5cdCQoZG9jdW1lbnQpLm9uKCdjbGljaycsICdbZGF0YS1jbGljaz1cImluY3JlYXNlLXF0eVwiXScsIGZ1bmN0aW9uKGUpIHtcclxuXHRcdGUucHJldmVudERlZmF1bHQoKTtcclxuXHRcdHZhciB0YXJnZXRJbnB1dCA9ICQodGhpcykuYXR0cignZGF0YS10YXJnZXQnKTtcclxuXHRcdHZhciB0YXJnZXRWYWx1ZSA9IHBhcnNlSW50KCQodGFyZ2V0SW5wdXQpLnZhbCgpKSArIDE7ICBcclxuXHRcdFxyXG5cdFx0JCh0YXJnZXRJbnB1dCkudmFsKHRhcmdldFZhbHVlKTtcclxuXHR9KTtcclxuXHQkKCdbZGF0YS1jbGljaz1cImRlY3JlYXNlLXF0eVwiXScpLmNsaWNrKGZ1bmN0aW9uKGUpIHtcclxuXHRcdGUucHJldmVudERlZmF1bHQoKTtcclxuXHRcdHZhciB0YXJnZXRJbnB1dCA9ICQodGhpcykuYXR0cignZGF0YS10YXJnZXQnKTtcclxuXHRcdHZhciB0YXJnZXRWYWx1ZSA9IHBhcnNlSW50KCQodGFyZ2V0SW5wdXQpLnZhbCgpKSAtIDE7ICBcclxuXHRcdCAgICB0YXJnZXRWYWx1ZSA9ICh0YXJnZXRWYWx1ZSA8IDApID8gMCA6IHRhcmdldFZhbHVlO1xyXG5cdFx0XHJcblx0XHQkKHRhcmdldElucHV0KS52YWwodGFyZ2V0VmFsdWUpO1xyXG5cdH0pO1xyXG59O1xyXG5cclxuXHJcbi8qIDA3LiBIYW5kbGUgUHJvZHVjdCBJbWFnZVxyXG4tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0gKi9cclxudmFyIGhhbmRsZVByb2R1Y3RJbWFnZSA9IGZ1bmN0aW9uKCkge1xyXG5cdCQoZG9jdW1lbnQpLm9uKCdjbGljaycsICdbZGF0YS1jbGljaz1cInNob3ctbWFpbi1pbWFnZVwiXScsIGZ1bmN0aW9uKGUpIHtcclxuXHRcdGUucHJldmVudERlZmF1bHQoKTtcclxuXHJcblx0XHR2YXIgdGFyZ2V0Q29udGFpbmVyID0gJ1tkYXRhLWlkPVwibWFpbi1pbWFnZVwiXSc7XHJcblx0XHR2YXIgdGFyZ2V0SW1hZ2UgPSAnPGltZyBzcmM9XCInKyAkKHRoaXMpLmF0dHIoJ2RhdGEtdXJsJykgKydcIiAvPic7XHJcblx0XHR2YXIgdGFyZ2V0TGkgPSAkKHRoaXMpLmNsb3Nlc3QoJ2xpJyk7XHJcblxyXG5cdFx0JCh0YXJnZXRDb250YWluZXIpLmh0bWwodGFyZ2V0SW1hZ2UpO1xyXG5cdFx0JCh0YXJnZXRMaSkuYWRkQ2xhc3MoJ2FjdGl2ZScpO1xyXG5cdFx0JCgnW2RhdGEtY2xpY2s9XCJzaG93LW1haW4taW1hZ2VcIl0nKS5jbG9zZXN0KCdsaScpLm5vdCh0YXJnZXRMaSkucmVtb3ZlQ2xhc3MoJ2FjdGl2ZScpO1xyXG5cdH0pO1xyXG59O1xyXG5cclxuXHJcbi8qIDA4LiBIYW5kbGUgUGFyb2xsZXJcclxuLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tICovXHJcbnZhciBoYW5kbGVQYXJvbGxlciA9IGZ1bmN0aW9uKCkge1xyXG5cdGlmICh0eXBlb2YgJC5mbi5wYXJvbGxlciAhPT0gJ3VuZGVmaW5lZCcpIHtcclxuXHRcdGlmICgkKCdbZGF0YS1wYXJvbGxlcj1cInRydWVcIl0nKS5sZW5ndGggIT09IDApIHtcclxuXHRcdFx0JCgnW2RhdGEtcGFyb2xsZXI9XCJ0cnVlXCJdJykucGFyb2xsZXIoKTtcclxuXHRcdH1cclxuXHR9XHJcbn07XHJcblxyXG5cclxuLyogMDkuIEhhbmRsZSBDaGVjayBCb290c3RyYXAgVmVyc2lvblxyXG4tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0gKi9cclxudmFyIGhhbmRsZUNoZWNrQm9vdHN0cmFwVmVyc2lvbiA9IGZ1bmN0aW9uKCkge1xyXG5cdHJldHVybiBwYXJzZUludCgkLmZuLnRvb2x0aXAuQ29uc3RydWN0b3IuVkVSU0lPTik7XHJcbn07XHJcblxyXG5cclxuLyogMTAuIEhhbmRsZSBHZXQgQ3NzIFZhcmlhYmxlXHJcbi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLSAqL1xyXG52YXIgZ2V0Q3NzVmFyaWFibGUgPSBmdW5jdGlvbih2YXJpYWJsZSkge1xyXG5cdHJldHVybiB3aW5kb3cuZ2V0Q29tcHV0ZWRTdHlsZShkb2N1bWVudC5ib2R5KS5nZXRQcm9wZXJ0eVZhbHVlKHZhcmlhYmxlKS50cmltKCk7XHJcbn07XHJcblxyXG5cclxuLyogQXBwbGljYXRpb24gQ29udHJvbGxlclxyXG4tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0gKi9cclxudmFyIEFwcCA9IGZ1bmN0aW9uICgpIHtcclxuXHRcInVzZSBzdHJpY3RcIjtcclxuXHRcclxuXHRyZXR1cm4ge1xyXG5cdFx0Ly9tYWluIGZ1bmN0aW9uXHJcblx0XHRpbml0OiBmdW5jdGlvbiAoKSB7XHJcblx0XHRcdGhhbmRsZUhlYWRlckZpeGVkVG9wKCk7XHJcblx0XHRcdGhhbmRsZVRvb2x0aXBQb3BvdmVyQWN0aXZhdGlvbigpO1xyXG5cdFx0XHRoYW5kbGVUaGVtZVBhbmVsRXhwYW5kKCk7XHJcblx0XHRcdGhhbmRsZVRoZW1lUGFnZUNvbnRyb2woKTtcclxuXHRcdFx0aGFuZGxlUGF5bWVudFR5cGVTZWxlY3Rpb24oKTtcclxuXHRcdFx0aGFuZGxlUXR5Q29udHJvbCgpO1xyXG5cdFx0XHRoYW5kbGVQcm9kdWN0SW1hZ2UoKTtcclxuXHRcdFx0aGFuZGxlUGFyb2xsZXIoKTtcclxuXHRcdFx0XHJcblx0XHRcdHRoaXMuaW5pdFZhcmlhYmxlKCk7XHJcblx0XHR9LFxyXG5cdFx0aW5pdFZhcmlhYmxlOiBmdW5jdGlvbigpIHtcclxuXHRcdFx0YXBwLmNvbG9yLnRoZW1lICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYXBwLXRoZW1lJyk7XHJcblx0XHRcdGFwcC5mb250LmZhbWlseSAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWJvZHktZm9udC1mYW1pbHknKTtcclxuXHRcdFx0YXBwLmZvbnQuc2l6ZSAgICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtYm9keS1mb250LXNpemUnKTtcclxuXHRcdFx0YXBwLmZvbnQud2VpZ2h0ICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtYm9keS1mb250LXdlaWdodCcpO1xyXG5cdFx0XHRhcHAuY29sb3IuY29tcG9uZW50Q29sb3IgPSBnZXRDc3NWYXJpYWJsZSgnLS1hcHAtY29tcG9uZW50LWNvbG9yJyk7XHJcblx0XHRcdGFwcC5jb2xvci5jb21wb25lbnRCZyAgICA9IGdldENzc1ZhcmlhYmxlKCctLWFwcC1jb21wb25lbnQtYmcnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmRhcmsgICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZGFyaycpO1xyXG5cdFx0XHRhcHAuY29sb3IubGlnaHQgICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1saWdodCcpO1xyXG5cdFx0XHRhcHAuY29sb3IuYmx1ZSAgICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1ibHVlJyk7XHJcblx0XHRcdGFwcC5jb2xvci5pbmRpZ28gICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWluZGlnbycpO1xyXG5cdFx0XHRhcHAuY29sb3IucHVycGxlICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1wdXJwbGUnKTtcclxuXHRcdFx0YXBwLmNvbG9yLnBpbmsgICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtcGluaycpO1xyXG5cdFx0XHRhcHAuY29sb3IucmVkICAgICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1yZWQnKTtcclxuXHRcdFx0YXBwLmNvbG9yLm9yYW5nZSAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtb3JhbmdlJyk7XHJcblx0XHRcdGFwcC5jb2xvci55ZWxsb3cgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLXllbGxvdycpO1xyXG5cdFx0XHRhcHAuY29sb3IuZ3JlZW4gICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1ncmVlbicpO1xyXG5cdFx0XHRhcHAuY29sb3Iuc3VjY2VzcyAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1zdWNjZXNzJyk7XHJcblx0XHRcdGFwcC5jb2xvci50ZWFsICAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLXRlYWwnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmN5YW4gICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtY3lhbicpO1xyXG5cdFx0XHRhcHAuY29sb3Iud2hpdGUgICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy13aGl0ZScpO1xyXG5cdFx0XHRhcHAuY29sb3IuZ3JheSAgICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1ncmF5Jyk7XHJcblx0XHRcdGFwcC5jb2xvci5saW1lICAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWxpbWUnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXkxMDAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS0xMDAnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXkyMDAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS0yMDAnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXkzMDAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS0zMDAnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXk0MDAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS00MDAnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXk1MDAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS01MDAnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXk2MDAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS02MDAnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXk3MDAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS03MDAnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXk4MDAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS04MDAnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXk5MDAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS05MDAnKTtcclxuXHRcdFx0YXBwLmNvbG9yLmJsYWNrICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtYmxhY2snKTtcclxuXHRcdFx0XHJcblx0XHRcdGFwcC5jb2xvci50aGVtZVJnYiAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWFwcC10aGVtZS1yZ2InKTtcclxuXHRcdFx0YXBwLmZvbnQuZmFtaWx5UmdiICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtYm9keS1mb250LWZhbWlseS1yZ2InKTtcclxuXHRcdFx0YXBwLmZvbnQuc2l6ZVJnYiAgICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtYm9keS1mb250LXNpemUtcmdiJyk7XHJcblx0XHRcdGFwcC5mb250LndlaWdodFJnYiAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWJvZHktZm9udC13ZWlnaHQtcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5jb21wb25lbnRDb2xvclJnYiA9IGdldENzc1ZhcmlhYmxlKCctLWFwcC1jb21wb25lbnQtY29sb3ItcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5jb21wb25lbnRCZ1JnYiAgICA9IGdldENzc1ZhcmlhYmxlKCctLWFwcC1jb21wb25lbnQtYmctcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5kYXJrUmdiICAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWRhcmstcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5saWdodFJnYiAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWxpZ2h0LXJnYicpO1xyXG5cdFx0XHRhcHAuY29sb3IuYmx1ZVJnYiAgICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1ibHVlLXJnYicpO1xyXG5cdFx0XHRhcHAuY29sb3IuaW5kaWdvUmdiICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1pbmRpZ28tcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5wdXJwbGVSZ2IgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLXB1cnBsZS1yZ2InKTtcclxuXHRcdFx0YXBwLmNvbG9yLnBpbmtSZ2IgICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtcGluay1yZ2InKTtcclxuXHRcdFx0YXBwLmNvbG9yLnJlZFJnYiAgICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtcmVkLXJnYicpO1xyXG5cdFx0XHRhcHAuY29sb3Iub3JhbmdlUmdiICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1vcmFuZ2UtcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci55ZWxsb3dSZ2IgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLXllbGxvdy1yZ2InKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyZWVuUmdiICAgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JlZW4tcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5zdWNjZXNzUmdiICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLXN1Y2Nlc3MtcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci50ZWFsUmdiICAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLXRlYWwtcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5jeWFuUmdiICAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWN5YW4tcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci53aGl0ZVJnYiAgICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLXdoaXRlLXJnYicpO1xyXG5cdFx0XHRhcHAuY29sb3IuZ3JheVJnYiAgICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1ncmF5LXJnYicpO1xyXG5cdFx0XHRhcHAuY29sb3IubGltZVJnYiAgICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1saW1lLXJnYicpO1xyXG5cdFx0XHRhcHAuY29sb3IuZ3JheTEwMFJnYiAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1ncmF5LTEwMC1yZ2InKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXkyMDBSZ2IgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS0yMDAtcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5ncmF5MzAwUmdiICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWdyYXktMzAwLXJnYicpO1xyXG5cdFx0XHRhcHAuY29sb3IuZ3JheTQwMFJnYiAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1ncmF5LTQwMC1yZ2InKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXk1MDBSZ2IgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS01MDAtcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5ncmF5NjAwUmdiICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWdyYXktNjAwLXJnYicpO1xyXG5cdFx0XHRhcHAuY29sb3IuZ3JheTcwMFJnYiAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1ncmF5LTcwMC1yZ2InKTtcclxuXHRcdFx0YXBwLmNvbG9yLmdyYXk4MDBSZ2IgICAgICAgID0gZ2V0Q3NzVmFyaWFibGUoJy0tYnMtZ3JheS04MDAtcmdiJyk7XHJcblx0XHRcdGFwcC5jb2xvci5ncmF5OTAwUmdiICAgICAgICA9IGdldENzc1ZhcmlhYmxlKCctLWJzLWdyYXktOTAwLXJnYicpO1xyXG5cdFx0XHRhcHAuY29sb3IuYmxhY2tSZ2IgICAgICAgICAgPSBnZXRDc3NWYXJpYWJsZSgnLS1icy1ibGFjay1yZ2InKTtcclxuXHRcdH1cclxuXHR9O1xyXG59KCk7XHJcblxyXG4kKGRvY3VtZW50KS5yZWFkeShmdW5jdGlvbigpIHtcclxuXHRBcHAuaW5pdCgpO1xyXG59KTsiXX0=
