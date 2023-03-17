<template>
	<Toast />
	<Toast position="bottom-right" group="br" />
	<div class="grid">
		<div class="col-12">
			<div class="card">
				<div style=" display: grid;">
					<h5>Metaveri</h5>
					<Dialog header="Metaveri Ekle" v-model:visible="displayModal"
						:breakpoints="{ '960px': '75vw', '640px': '90vw' }" :style="{ width: '50vw' }" :modal="true">
						<div class="login-input-wrapper">
							<InputText placeholder="Metaveri Adı" type="name" class="form-control" v-model="name" />
						</div>
						<Dropdown v-model="typeId" :options="dropdownValues" optionLabel="name"
							placeholder="Metaveri Tipi" />
						<template #footer>
							<Button label="No" icon="pi pi-times" @click="closeModal" class="p-button-text" />
							<Button label="Yes" icon="pi pi-check" @click="addLookup" autofocus />
						</template>
					</Dialog>
					<Button label="Yeni Metaveri Ekle" icon="pi pi-plus" @click="openModal" />
				</div>
				<DataTable :value="lookups" dataKey="id">
					<Column field="name" header="Metaveri Adı" style="min-width:200px"></Column>
					<Column field="typeName" header="Metaveri Tipi" style="min-width:200px"></Column>
					<Column field="isActive" header="Metaveri Durumu" style="min-width:200px"></Column>
					<Column headerStyle="width: 8em" bodyStyle="text-align: center">
						<template #body="slotProps">
							<span class="p-buttonset">
								<Dialog header="Metaveri Düzenle" v-model:visible="displayModalEdit"
									:breakpoints="{ '960px': '75vw', '640px': '90vw' }" :style="{ width: '50vw' }"
									:modal="true">
									<div class="login-input-wrapper">
										<InputText placeholder="Metaveri Id" type="Id" class="form-control"
											v-model="lookupId" />
									</div>
									<div class="login-input-wrapper">
										<InputText placeholder="Metaveri Adı" type="name" class="form-control"
											v-model="lookupName" />
									</div>
									<template #footer>
										<Button label="No" icon="pi pi-times" @click="closeModal"
											class="p-button-text" />
										<Button label="Yes" icon="pi pi-check" @click="saveLookup" autofocus />
									</template>
								</Dialog>
								<ConfirmDialog :group="slotProps.data.id" />
								<Button label="" icon="pi pi-pencil" @click="editLookup(slotProps.data.id)" />
								<Button field="id" label="" icon="pi pi-trash"
									@click="deleteLookup(slotProps.data.id)" />
							</span>
						</template>
					</Column>
				</DataTable>
			</div>
		</div>
	</div>
</template>

<script>
import { FilterMatchMode, FilterOperator } from 'primevue/api';
import CustomerService from "../service/CustomerService";
import ProductService from '../service/ProductService';
export default {
	name: "LookupPage",
	data() {
		return {
			lookupId: null,
			lookupName: null,
			dropdownValues: [],
			name: null,
			typeId: null,
			lookups: [],
			displayModal: false,
			displayModalEdit: false,
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
				'global': { value: null, matchMode: FilterMatchMode.CONTAINS },
				'name': { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }] },
				'country.name': { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.STARTS_WITH }] },
				'representative': { value: null, matchMode: FilterMatchMode.IN },
				'date': { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.DATE_IS }] },
				'balance': { operator: FilterOperator.AND, constraints: [{ value: null, matchMode: FilterMatchMode.EQUALS }] },
				'status': { operator: FilterOperator.OR, constraints: [{ value: null, matchMode: FilterMatchMode.EQUALS }] },
				'activity': { value: null, matchMode: FilterMatchMode.BETWEEN },
				'verified': { value: null, matchMode: FilterMatchMode.EQUALS }
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
			return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
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
				.get(`api/management/lookup/list`)
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
		addLookup() {
			this.isFailed = false;
			const d = {
				name: this.name,
				typeId: this.typeId.id
			};
			this.$ajax.post("api/management/lookup/add", d).then((response) => {
				if (response.data) {
					this.$toast.add({ severity: 'success', summary: 'Onaylandı', detail: 'İşleminiz tamamlandı', life: 3000 });
					this.loadData();
					this.displayModal = false;
				} else {
					this.$toast.add({ severity: 'error', summary: 'Kötü İstek', detail: 'Bir şeyler ters gitti!', life: 3000 });
				}
			});
		},
		dropdown() {
			this.$ajax
				.get(`api/management/lookupType/list`)
				.then((response) => {
					if (response.data) {
						this.dropdownValues = response.data;
					}
				})
				.catch((error) => {
					if (error) {
						this.isFailed = true;
					}
				});
		},
		getLookupProps(id) {
			this.$ajax
				.get(`api/management/lookup/get/${id}`)
				.then((response) => {
					if (response.data) {
						this.lookupId = response.data.id;
						this.lookupName = response.data.name;
					}
				})
				.catch((error) => {
					if (error) {
						this.isFailed = true;
					}
				});
		},
		editLookup(id) {
			this.displayModalEdit = true;
			this.getLookupProps(id);
		},
		saveLookup() {
			const d = {
				id: this.lookupId,
				name: this.lookupName
			};
			this.$ajax.put("api/management/lookup/update", d).then((response) => {
				if (response.data) {
					this.$toast.add({ severity: 'success', summary: 'Onaylandı', detail: 'İşleminiz tamamlandı', life: 3000 });
					this.loadData();
					this.displayModalEdit = false;
				} else {
					this.$toast.add({ severity: 'error', summary: 'Kötü İstek', detail: 'Bir şeyler ters gitti!', life: 3000 });
				}
			});
		},
		openModal() {
			this.displayModal = true;
			this.dropdown();
		},
		closeModal() {
			this.displayModal = false;
		},
		deleteLookup(id) {
			this.$confirm.require({
				group: id,
				header: 'Onaylama Metni',
				message: 'Silmek istediğinize emin misiniz?',
				icon: 'pi pi-exclamation-triangle',
				accept: () => {
					this.$ajax.delete(`api/management/lookup/delete/${id}`).then(() => {
						this.$toast.add({ severity: 'success', summary: 'Onaylandı', detail: 'İşleminiz tamamlandı', life: 3000 });
						this.lookups = this.lookups.filter((item) => item.id !== id);
					}).catch(() => {
						this.$toast.add({ severity: 'error', summary: 'Kötü İstek', detail: 'Bir şeyler ters gitti!', life: 3000 });
					})
					console.log(this.lookups.filter((item) => item.id !== id));
				},
				reject: () => {
					this.$toast.add({ severity: 'error', summary: 'İptal', detail: 'İşlemi iptal ettiniz', life: 3000 });
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
