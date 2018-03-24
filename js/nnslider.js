/*
 * NNSlider 0.1
 * http://url.com
 * Author: Abdel Hanin
 * This is a simple Gallery Slider, Biuld With jquery.
 * Copyright 2015, Abdel Hanin
 * Free to use and abuse under the MIT license.
 * http://www.opensource.org/licenses/mit-license.php
 */

$(window).load(function(){   	
		
	$('.slider-content').after('<div class="paginator"><ul></ul></div>');
	$( ".slider-content > *" ).each( function( index, el ) {
    	if(index == 0){
    		$('.paginator ul').append('<li><span data-index="'+index+'" class="active"></span></li>');
    	}else{
    		$('.paginator ul').append('<li><span data-index="'+index+'"></span></li>');
    	}
	});
	$('.paginator').after('<div class="controls"><span class="prev"></span><span class="next"></span></div>');

	matchHeight();

	$( window ).resize(function() {
		matchHeight();
	});

	//make the slider content as Image height
	function matchHeight(){		
		sliderHeight = $('.slider-content img:visible').outerHeight();
		
		$('.slider-wrapper').height(sliderHeight);			
	}
	
	
	$('.paginator span').click(function(){					
		slideIndex = $(this).attr('data-index');		
		changeSlide(slideIndex);		
			
	});
	
	
	//Function Which moves the slide and controls active status
	function changeSlide(indexSlide){
		
		$('.slider-content > *').fadeOut(800);					
		$('.slider-content > *').eq(indexSlide).fadeIn(1500,function(){
		});		
		
		$('.paginator span').removeClass('active');
		$('.paginator span').eq(indexSlide).addClass('active');

	}


	
	//Returns the active Slide
	function activeSlide(){
		actualSlide = $('.slider-content > *:visible');
		slideIndex = $(actualSlide).index();
		
		if($(actualSlide).is(':last-child')){
			slideIndex = -1;			
		}

		return slideIndex;
	}


	$('.controls span.prev').click(function(){		
		changeSlide(activeSlide()-1);
	});

	$('.controls span.next').click(function(){		
		changeSlide(activeSlide()+1);
	});

	
	function autoControl(){
		autoSlider = setInterval(function(){
		  changeSlide(activeSlide()+1);
		}, 2500);
	}

	autoControl();
	
	//Clears the auto Slide when the mouse is over
	$('.slider-wrapper').mouseenter(function(){
		clearInterval(autoSlider);
	});

	//Start the auto Slide when mouse leaves
	$('.slider-wrapper').mouseleave(function(){
		autoControl();
	});


});