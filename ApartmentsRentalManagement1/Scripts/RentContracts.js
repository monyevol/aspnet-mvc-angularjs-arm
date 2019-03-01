appRentManagement.controller("RentContractsController", ["$scope", "$http", function ($scope, $http) {
    $http({
        method: 'GET',
        url: '/api/RentContracts'
    }).
        then(function (response) {
            $scope.contracts = response.data;
        },
            function (response) {
                $scope.error = "The server could not produce a list of rent contracts.";
            }
        );

    $scope.findEmployee = function () {
        $http({
            method: 'GET',
            url:    '/api/Employees'
        }).
            then(function (response) {
                for (var staff in response.data) {
                    if (response.data[staff].EmployeeNumber === $scope.emplNumber) {
                        $scope.employeeDetails = response.data[staff].FirstName + " " + response.data[staff].LastName + " (" + response.data[staff].EmploymentTitle + ")";
                    }
                }
            },
                function (response) {
                    $scope.error = "The server could not retrieve the information about the employee.";
                }
            );
    };

    $scope.findApartment = function () {
        $http({
            method: 'GET',
            url: '/api/Apartments'
        }).
            then(function (response) {
                for (var aprt in response.data) {
                    if (response.data[aprt].UnitNumber === $scope.unitNumber) {
                        $scope.apartDetails = response.data[aprt].Residence;
                    }
                }
            },
                function (response) {
                    $scope.error = "The server could not retrieve the information about the apartment.";
                }
            );
    };

    $scope.findRentContract = function () {
        $http({
            method: 'GET',
            url: '/api/RentContracts'
        }).
            then(function (response) {
                for (var rent in response.data) {
                    if (response.data[rent].RentContractId === $scope.contractId) {
                        $scope.contractNumber = response.data[rent].ContractNumber;
                        $scope.emplNumber = response.data[rent].EmployeeNumber;
                        $scope.contractDate = response.data[rent].ContractDate;
                        $scope.firstName = response.data[rent].FirstName;
                        $scope.lastName = response.data[rent].LastName;
                        $scope.maritalStatus = response.data[rent].MaritalStatus;
                        $scope.nbrOfChildren = response.data[rent].NumberOfChildren;
                        $scope.unitNumber = response.data[rent].UnitNumber;
                        $scope.rsd = response.data[rent].RentStartDate;
                    }
                }
            },
                function (response) {
                    $scope.error = "The server could not retrieve the information about the rent contract.";
                }
            );
    };

    $scope.locateRentContract = function () {
        $http({
            method: 'GET',
            url: '/api/RentContracts'
        }).
            then(function (response) {
                for (var rent in response.data) {
                    if (response.data[rent].ContractNumber === $scope.contractNumber) {
                        $scope.contractId = response.data[rent].RentContractId;
                        $scope.emplNumber = response.data[rent].EmployeeNumber;
                        $scope.contractDate = response.data[rent].ContractDate;
                        $scope.firstName = response.data[rent].FirstName;
                        $scope.lastName = response.data[rent].LastName;
                        $scope.maritalStatus = response.data[rent].MaritalStatus;
                        $scope.nbrOfChildren = response.data[rent].NumberOfChildren;
                        $scope.unitNumber = response.data[rent].UnitNumber;
                        $scope.rsd = response.data[rent].RentStartDate;
                    }
                }
            },
                function (response) {
                    $scope.error = "The server could not retrieve the information about the rent contract.";
                }
            );

        $scope.findEmployee();
        $scope.findApartment();
    };

    $scope.saveRentContract = function () {
        var contract = {
            ContractNumber: $scope.contractNumber,
            EmployeeNumber: $scope.emplNumber,
            ContractDate: $scope.contractDate,
            FirstName: $scope.firstName,
            LastName: $scope.lastName,
            MaritalStatus: $scope.maritalStatus,
            NumberOfChildren: $scope.nbrOfChildren,
            UnitNumber: $scope.unitNumber,
            RentStartDate: $scope.rsd
        };

        $http({
            method: 'POST',
            url: '/api/RentContracts',
            data: contract
        }).
            then(function (response) {
                $scope.RentContracts.push(response.data);
            },
                function (response) {
                    $scope.error = "The record could not be saved.";
                });
    };

    $scope.updateRentContract = function () {
        var contract = {
            RentContractId: $scope.contractId,
            ContractNumber: $scope.contractNumber,
            EmployeeNumber: $scope.emplNumber,
            ContractDate: $scope.contractDate,
            FirstName: $scope.firstName,
            LastName: $scope.lastName,
            MaritalStatus: $scope.maritalStatus,
            NumberOfChildren: $scope.nbrOfChildren,
            UnitNumber: $scope.unitNumber,
            RentStartDate: $scope.rsd
        };

        $http({
            method: 'PUT',
            url: '/api/RentContracts/' + Number($scope.contractId || 0),
            data: contract
        }).
            then(function (response) {
                $scope.RentContracts = response.data;
            },
                function (response) {
                    $scope.error = "The record could not be saved.";
                });
    };

    $scope.deleteRentContract = function () {
        var contract = {
            RentContractId: $scope.contractId,
            ContractNumber: $scope.contractNumber,
            EmployeeNumber: $scope.emplNumber,
            ContractDate: $scope.contractDate,
            FirstName: $scope.firstName,
            LastName: $scope.lastName,
            MaritalStatus: $scope.maritalStatus,
            NumberOfChildren: $scope.nbrOfChildren,
            UnitNumber: $scope.unitNumber,
            RentStartDate: $scope.rsd
        };

        $http({
            method: 'DELETE',
            url: '/api/RentContracts/' + Number($scope.contractId || 0),
            data: contract
        }).
            then(function (response) {
                $scope.RentContracts.splice(response.data, 1);
            },
                function (response) {
                    $scope.error = "The record could not be saved.";
                });
    };
}]);