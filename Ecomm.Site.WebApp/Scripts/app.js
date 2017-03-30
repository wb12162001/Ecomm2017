// Place third party dependencies in the lib folder
//
// Configure loading modules from the lib directory,
// except 'app' ones, 
requirejs.config({
    baseUrl: "/",
	paths: {
	    'jquery': "Scripts/jquery-1.9.1.min",
	    'angular': 'Scripts/angular.min',
	    'router': 'Scripts/AngularUI/ui-router',
	    "bootstrap": "Scripts/bootstrap",
	    "bootstrapvalidator": "Content/plugins/bootstrapvalidator/js/bootstrapValidator.min",
	},
	shim: {
		"jquery":{
			exports: 'jquery'
		},
		'angular': {
			exports: 'angular'
		},
		'bootstrap': {
		    deps : [ 'jquery' ],  
		    exports : 'bootstrap'
		},
		'bootstrapvalidator': {
		    deps: ['jquery', 'bootstrap'],
		    exports: 'bootstrapvalidator'
		},
	}
});

// Load the main app module to start the app
requirejs(["Scripts/app/main"]);