<template>
	<div class="grid">
		<div class="col-12">
			<div class="card">
				<h5>Metaveri Tipi</h5>
				<DataTable :value="lookups">
                    <Column field="name" header="Metaveri Tipi" style="min-width:200px"></Column>
                    <Column field="isActive" header="Metaveri Durumu" style="min-width:200px"></Column>
                </DataTable>
			</div>
		</div>
	</div>
</template>

<script>
import {FilterMatchMode,FilterOperator} from 'primevue/api';
import CustomerService from "../service/CustomerService";
import ProductService from '../service/ProductService';
export default {
	name: "LookupPage",
	data() {
		return {
			lookups: [],
			filters1: null,
			filters2: {},
			loading1: true,
			loading2: true,
			idFrozen: false,
			products: null,
			expandedRows: [],
		}
	},
	customerService: null,
	productService: null,
	created() {
		this.customerService = new CustomerService();
		this.productService = new ProductService();
		this.initFilters1();
	},
	mounted() {
		this.loadData();
	},
	methods: {
		initFilters1() {
			this.filters1 = {
				'global': {value: null, matchMode: FilterMatchMode.CONTAINS},
				'name': {operator: FilterOperator.AND, constraints: [{value: null, matchMode: FilterMatchMode.STARTS_WITH}]},
				'country.name': {operator: FilterOperator.AND, constraints: [{value: null, matchMode: FilterMatchMode.STARTS_WITH}]},
				'representative': {value: null, matchMode: FilterMatchMode.IN},
				'date': {operator: FilterOperator.AND, constraints: [{value: null, matchMode: FilterMatchMode.DATE_IS}]},
				'balance': {operator: FilterOperator.AND, constraints: [{value: null, matchMode: FilterMatchMode.EQUALS}]},
				'status': {operator: FilterOperator.OR, constraints: [{value: null, matchMode: FilterMatchMode.EQUALS}]},
				'activity': {value: null, matchMode: FilterMatchMode.BETWEEN},
				'verified': {value: null, matchMode: FilterMatchMode.EQUALS}
			}
		},
		clearFilter1() {
			this.initFilters1();
		},
		expandAll() {
			this.expandedRows = this.products.filter(p => p.id);
		},
		collapseAll() {
			this.expandedRows = null;
		},
		formatCurrency(value) {
			return value.toLocaleString('en-US', {style: 'currency', currency: 'USD'});
		},
		formatDate(value) {
			return value.toLocaleDateString('en-US', {
				day: '2-digit',
				month: '2-digit',
				year: 'numeric',
			});
		},
		loadData() {
			this.$ajax
				.get(`api/management/lookuptype/list`)
				.then((response) => {
					if (response.data) {
						this.lookups = response.data;
					}
				})
				.catch((error) => {
					if (error) {
						this.isFailed = true;
					}
				});
    },
  },
};
</script>

<style scoped lang="scss">
@import '../assets/demo/styles/badges.scss';

::v-deep(.p-datatable-frozen-tbody) {
	font-weight: bold;
}

::v-deep(.p-datatable-scrollable .p-frozen-column) {
	font-weight: bold;
}

::v-deep(.p-progressbar) {
	height: .5rem;
	background-color: #D8DADC;

	.p-progressbar-value {
		background-color: #607D8B;
	}
}
</style>
