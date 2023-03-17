<template>
<Toast />
	<Toast position="bottom-right" group="br" />
	<div class="grid">
		<div class="col-12">
			<div class="card">
				<div style=" display: grid;"></div>
				<h5>Şirketler</h5>
				<Dialog header="Şirket Ekle" v-model:visible="displayModal"
					:breakpoints="{ '960px': '75vw', '640px': '90vw' }" :style="{ width: '50vw' }" :modal="true">
					<div class="login-input-wrapper">
						<InputText placeholder="Şirket Adı" type="name" class="form-control" v-model="companyName" style="width:600px;margin:5px"/>
						<InputText placeholder="Açıklama" type="companyDescription" class="form-control" v-model="companyDescription" style="width:600px;margin:5px" />
						<InputText placeholder="Üyelik Planı" type="membershipPlan" class="form-control" v-model="membershipPlan" style="width:600px;margin:5px"/>
            <Calendar  placeholder="Üyelik Başlangıç Tarihi" id="membershipStartDate" v-model="membershipStartDate" class="p-invalid" :showIcon="true" style="width:600px;margin:5px" />
            <Calendar  placeholder="Üyelik Bitiş Tarihi" id="membershipEndDate" v-model="membershipEndDate" class="p-invalid" :showIcon="true" style="width:600px;margin:5px" />
						<InputText placeholder="Email" type="supportEmail" class="form-control" v-model="supportEmail" style="width:600px;margin:5px" />
						<Dropdown v-model="isActive" :options="dropdownIsActive" optionLabel="durum"	placeholder="Üyelik Durum" style="margin:5px" />
					</div>
					<template #footer>
						<Button label="Hayır" icon="pi pi-times" @click="closeModal" class="p-button-text" />
						<Button label="Evet" icon="pi pi-check" @click="addCompany" autofocus />
					</template>
				</Dialog>
				<Button label="Şirket Ekle" icon="pi pi-plus" @click="openModal" />
			</div>
			<div>
				<DataTable :value="companies">
					<Column field="companyName" header="Şirket Adı" style="min-width:20px"></Column>
					<Column field="id" header="Id" style="min-width:20px"></Column>
					<Column field="companyDescription" header="Açıklama" style="min-width:20px"></Column>
					<Column field="membershipPlan" header="Üyelik Planı" style="min-width:20px"></Column>
					<Column field="membershipStartDate" header="Başlangıç Tarihi" style="min-width:20px"></Column>
					<Column field="membershipEndDate" header="Bitiş Tarihi" style="min-width:20px"></Column>
					<Column field="supportEmail" header="Mail Adresi" style="min-width:20px"></Column>
					<Column field="isActive" header="Şirket Durumu" style="min-width:20px"></Column>
					<Column header="İşlemler" style="min-width:20px"> <template #body="slotProps">
							<span class="p-buttonset">
								<Dialog header="Şirket Düzenle" v-model:visible="displayModalEdit"
									:breakpoints="{ '960px': '75vw', '640px': '90vw' }" :style="{ width: '50vw' }" :modal="true">
									<div class="login-input-wrapper">
										<InputText placeholder="Şirket Id" type="id" class="form-control" v-model="id" />
									</div>
									<div class="login-input-wrapper">
										<InputText placeholder="Şirket Adı" type="name" class="form-control" v-model="companyName" />
									</div>
									<template #footer>
										<Button label="No" icon="pi pi-times" @click="closeModal" class="p-button-text" />
										<Button label="Yes" icon="pi pi-check" @click="saveCompany" autofocus />
									</template>
								</Dialog>
								<ConfirmDialog :group="slotProps.data.id" />
								<Button label="" icon="pi pi-pencil" @click="editCompany(slotProps.data.id)" />
								<Button field="id" label="" icon="pi pi-trash" @click="deleteCompany(slotProps.data.id)" />
							</span>
						</template></Column>

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
	name: "CompanyPage",
	data() {
		return {
			dropdownIsActive:[
			{durum: `Aktif`,kod:`a`},
			{durum: `Pasif`,kod:`p`}
			],
			id: null,
			companyName:null,
			companyDescription:null,
			membershipStartDate:null,
			membershipEndDate:null,
			supportEmail:null,
			isActive:false,
			membershipPlan:null,
			companies: [],
			filters1: null,
			filters2: {},
			loading1: true,
			loading2: true,
			idFrozen: false,
			products: null,
			expandedRows: [],
			displayModal: false,
			displayModalEdit: false,
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
		addCompany() {
			this.isFailed = false;
			const d = {
				companyName: this.companyName,
				companyDescription:this.companyDescription,
					membershipStartDate:this.membershipStartDate,
					membershipEndDate:this.membershipEndDate,
					supportEmail:this.supportEmail,
					isActive:this.isActive,
					membershipPlan:this.membershipPlan,
					};
			this.$ajax.post(`api/company/add`, d).then((response) => {
				if (response.data) {
					this.$toast.add({ severity: 'success', summary: 'Onaylandı', detail: 'İşleminiz tamamlandı', life: 3000 });
					this.loadData();
					this.displayModal = false;
				} else {
					this.$toast.add({ severity: 'error', summary: 'Kötü İstek', detail: 'Bir şeyler ters gitti!', life: 3000 });
				}
			});
		},
		loadData() {
			this.$ajax
				.get(`api/company/list`)
				.then((response) => {
					if (response.data) {
						this.companies = response.data;
					}
				})
				.catch((error) => {
					if (error) {
						this.isFailed = true;
					}
				});
		},
		getCompanyProps(id) {
			this.$ajax
				.get(`api/company/get/${id}`)
				.then((response) => {
					if (response.data) {
						this.id = response.data.id;
						this.companyName = response.data.companyName;
					}
				})
				.catch((error) => {
					if (error) {
						this.isFailed = true;
					}
				});
		},
		editCompany(id) {
			this.displayModalEdit = true;
			this.getCompanyProps(id);
		},
		saveCompany() {
			const d = {
				companyName: this.companyName
			};
			console.log(d);
			this.$ajax.put(`api/company/update`, d).then((response) => {
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
		},
		closeModal() {
			this.displayModal = false;
		},
		deleteCompany(id) {
			this.$confirm.require({
				group: id,
				header: 'Onaylama Metni',
				message: 'Silmek istediğinize emin misiniz?',
				icon: 'pi pi-exclamation-triangle',
				accept: () => {
					this.$ajax.delete(`api/company/delete/${id}`).then(() => {
						this.$toast.add({ severity: 'success', summary: 'Onaylandı', detail: 'İşleminiz tamamlandı', life: 3000 });
						this.companies = this.companies.filter((item) => item.id !== id);
					}).catch(() => {
						this.$toast.add({ severity: 'error', summary: 'Kötü İstek', detail: 'Bir şeyler ters gitti!', life: 3000 });
					})
					console.log(this.companies.filter((item) => item.id !== id));
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
	.inputtext {
		margin-right: .5rem;
		width: 400px;
	}
}
</style>
