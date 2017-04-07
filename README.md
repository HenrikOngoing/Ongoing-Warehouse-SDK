<a href="http://www.ongoingwarehouse.com">![Logo](http://www.ongoingwarehouse.com/images/logotype.png)</a>
# Ongoing Warehouse .NET SDK and integration examples
A simple .NET-based SDK wrapping the SOAP API of Ongoing Warehouse WMS. The repository also contains simple example integrations for different purposes.

A typical integration consists of a set of scheduled tasks to receive data from the WMS and a set of event-based tasks to transmit data to the WMS.

## <a href="https://github.com/HenrikOngoing/Ongoing-Warehouse-SDK/tree/master/OngoingWarehouse.Sdk.Example.Webshop">Webshop</a>
<a href="https://github.com/HenrikOngoing/Ongoing-Warehouse-SDK/tree/master/OngoingWarehouse.Sdk.Example.Webshop">OngoingWarehouse.Sdk.Example.Webshop</a> is a minimal example which illustrates how the SDK can be used for seamless integratation with a webshop.
The integration consists of four tasks. Two event-based and two scheduled tasks. When something is changed in the webshop either the <i>UpdateArticleInOngoingTask</i> or the <i>UpdateOrderInOngoingTask</i> should be executed depending on the type of change.
The scheduled tasks should be executed ongoing. For example every 15 minutes. The tasks will retrieve available stock and the status of orders placed.

## <a href="https://github.com/HenrikOngoing/Ongoing-Warehouse-SDK/tree/master/OngoingWarehouse.Sdk.Example.Erp">ERP</a>
An ERP integration is generally a superset of a webshop integration. The code should be used in combination with what is provides in <a href="https://github.com/HenrikOngoing/Ongoing-Warehouse-SDK/tree/master/OngoingWarehouse.Sdk.Example.Webshop">OngoingWarehouse.Sdk.Example.Webshop</a>. 

<div>
	<a href="https://ci.appveyor.com/project/freein/ongoing-warehouse-sdk?svg=true">
		<img src="https://ci.appveyor.com/api/projects/status/github/HenrikOngoing/ongoing-warehouse-sdk?svg=true" alt="Project Badge" width="200">
	</a>
</div>