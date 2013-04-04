$(function () {
    $(".glossaryForm").dialog({
        modal: true,
        width: 430,
        height: 290,
        autoOpen: false
    });

    $(".errorDialog").dialog({
        modal: true,
        width: 430,
        height: 300,
        autoOpen: false 
    });
});

var ajaxDispatcher = new AjaxDispatcher();

GlossaryModel = function() {

    var self = this;
    self.terms = ko.observableArray();
    self.addFormTerm = ko.observable("");
    self.addFormDefinition = ko.observable("");
    self.orderAsc = ko.observable(true);
    self.currentTerm = ko.observable(null);
    self.addFormVisible = ko.observable(false);
    self.errorDialogVisible = ko.observable(false);
    self.currentError = ko.observable({statusText: ""});

    self.addFormDialog = ko.computed(function() {
        if(self.addFormVisible())
            $(".glossaryForm").dialog('open');
        else
            $(".glossaryForm").dialog('close');
    });
    
    self.showHideErrorDialog = ko.computed(function() {
        if(self.errorDialogVisible())
            $(".errorDialog").dialog('open');
        else
            $(".errorDialog").dialog('close');
    });

    self.init = function () {
        self.refresh();
    };

    self.changeOrder = function () {
        self.orderAsc(!self.orderAsc());
        self.refresh();
    };

    self.refresh = function () {
        var request = {
            type: "GET",
            url: "api/term/get?asc=" + self.orderAsc()
        };
        var response = ajaxDispatcher.send(request);
        response.done(function (d) {
            self.terms(d);
            $(".nano").nanoScroller();
        });
        response.fail(function (e) {
            self.currentError(e);
            self.errorDialogVisible(true);
        });
    };

    self.cancel = function () {
        self.addFormVisible(false);
        self.errorDialogVisible(false);
    };
    
    self.confirm = function () {
        var data = {
            Id: self.currentTerm() ? self.currentTerm().Id : 0,
            Name: self.addFormTerm(),
            Definition: self.addFormDefinition()
        };

        var request = {
            type: "POST",
            url: "api/term/create",
            data: JSON.stringify(data)
        };

        if(data.Id !== 0)
            request.url = "api/term/update";

        var response = ajaxDispatcher.send(request);
        response.done(function (d) {
            self.addFormVisible(false);
            self.refresh();
        });
        response.fail(function (e) {
            self.currentError(e);
            self.errorDialogVisible(true);
        });
    };

     self.editTerm = function (term) {
        self.addFormVisible(true);
        self.currentTerm(term);
        self.addFormTerm(term.Name);
        self.addFormDefinition(term.Definition);
    };
    
    self.deleteTerm = function (term) {
        var request = {
            type: "POST",
            url: "api/term/delete/" + term.Id
        };
        var response = ajaxDispatcher.send(request);
        response.done(function (d) {
            self.refresh();
        });
        response.fail(function (e) {
            self.currentError(e);
            self.errorDialogVisible(true);
        });
    };

    self.addNew = function() {
        self.addFormVisible(true);
        self.currentTerm(null);
        self.addFormTerm("");
        self.addFormDefinition("");
    };
};

$(function () {
    var viewModel = new GlossaryModel();
    viewModel.init();
    ko.applyBindings(viewModel);
});