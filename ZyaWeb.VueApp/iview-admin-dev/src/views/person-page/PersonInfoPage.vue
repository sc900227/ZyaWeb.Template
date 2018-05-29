<style lang="less">
</style>

<template>
    <div>
      <Card>
        <p slot="title">
          <Icon type="help-buoy"></Icon>人员管理
        </p>
            <crud-table :table-data="tableData" :columns="columns" :total="total" :page-option="pageOption"
                          :on-ok="handleOk" 
                          :table-loading="tableLoading"
                          @on-pre-add="handlePreAdd"
                          @on-pre-edit="handlePreEdit"
                          @on-page-change="handlePageChange"
                          @on-sort-change="handleSort"
                          @on-delete="handleDelete">
                  <Form slot="modal-content" ref="crudItem"
                        :model="crudItem" 
                        :rules="ruleValidate" label-position="right" :label-width="100">
                        <FormItem label='"姓名"' prop='Name'><Input v-model='crudItem.Name' placeholder=''></Input></FormItem><FormItem label='"邮箱"' prop='EmailAddress'><Input v-model='crudItem.EmailAddress' placeholder=''></Input></FormItem><FormItem label='"电话号码"' prop='PhoneNumber'><Input v-model='crudItem.PhoneNumber' placeholder=''></Input></FormItem>
                  </Form>
                  <Row slot="filter" :gutter="16">
                    <Col span="8">
                        <Input v-model="filterEnter.textInput" placeholder="试剂盒名称..."></Input>
                    </Col>
                    
                    <Button type="primary" icon="search" @click="fetchData">搜索</Button>
                    
                </Row>
              </crud-table>
      </Card>
    </div>
</template>

<script>
import CrudTable from "../common/crudTable.vue";

export default {
  name: "PersonInfoPage",
  components: {
    CrudTable
  },
  data() {
    return {
      columns: [{"title":"编号","key":"id","sortable":"custom","handle":""},{"title":"\"姓名\"","key":"name","sortable":"custom","handle":""},{"title":"\"邮箱\"","key":"emailAddress","sortable":"custom","handle":""},{"title":"\"电话号码\"","key":"phoneNumber","sortable":"custom","handle":""},{"title":"","key":"articles","sortable":"custom","handle":""},{ 'title': '操作','key': 'action','handle':['edit', 'delete']}],
      tableData: [],
      pageOption: { pageIndex: 1, pageSize: 10 },
      total: 0,
      tableLoading: true,
      filterEnter: {},
      orderBy: "ID",
      url: "api/services/app/Person/",
      header: {
        headers: { "Content-Type": "application/json" }
      },
      crudItem: {
        Id:null,Name:null,EmailAddress:null,PhoneNumber:null,Articles:null
      },
      ruleValidate: {
        Id:[{"required":true,"message":"不能为空！","trigger":"blur"}],Name:[{"required":true,"message":"\"姓名\"不能为空！","trigger":"blur"}],EmailAddress:[{"required":true,"message":"\"邮箱\"不能为空！","trigger":"blur"}],PhoneNumber:[{"required":true,"message":"\"电话号码\"不能为空！","trigger":"blur"}],Articles:[{"required":true,"message":"不能为空！","trigger":"blur"}]
      }
    };
  },
  mounted() {
    this.fetchData();
  },
  computed: {
    filterKey() {
      let filter = this.filterEnter;
      let strFilter = [];
      let str = {};
      if (filter) {
        if (filter.textInput) {
          str.ColumName = "ReagentName";
          str.ColumValue = filter.textInput;
          strFilter.push(str);
          return strFilter;
        }
        return "";
      } else {
        return "";
      }
    }
  },
  methods: {
    fetchData() {
      let vm = this;

      vm.tableLoading = true;
      let params = {
        Sorting: vm.orderBy || undefined,
        SkipCount: (vm.pageOption.pageIndex - 1) * vm.pageOption.pageSize,
        MaxResultCount: vm.pageOption.pageSize,
        Filter: vm.filterKey || undefined
      };

      vm.$http
        .get(vm.url + "GetPagedPersons", params, vm.header)
        .then(response => {
          console.log(response);
          vm.tableData = response.data.result["items"];
          vm.total = Number(response.data.result["totalCount"]);
          vm.tableLoading = false;
        })
        .catch(error => {
          console.log(error);
        });
    },
    handleSort(order) {
      this.orderBy = order.replace(" ", "-");
      this.fetchData();
    },
    handlePageChange(pageOpt) {
      let vm = this;
      vm.pageOption = JSON.parse(JSON.stringify(pageOpt));
      vm.fetchData();
    },
    handleOk() {
      let vm = this;
      let params = {person:{
        Id:vm.crudItem.Id,Name:vm.crudItem.Name,EmailAddress:vm.crudItem.EmailAddress,PhoneNumber:vm.crudItem.PhoneNumber,Articles:vm.crudItem.Articles
      }};

      return new Promise(resolve => {
        vm.$refs["crudItem"].validate(valid => {
          if (valid) {
            let promise = null;
            vm.crudItem.Id = vm.crudItem.Id || undefined;
            if (!vm.crudItem.Id) {
              promise = vm.$http.post(
                vm.url + "CreateOrUpdatePerson",
                params,
                vm.header
              );
            } else {
              promise = vm.$http.post(
                vm.url + "CreateOrUpdatePerson",
                params,
                vm.header
              );
            }

            promise
              .then(res => {
                resolve(true);
                vm.fetchData();
              })
              .catch(err => {
                console.log(err);
              });
          } else {
            resolve(false);
          }
        });
      });
    },
    handlePreAdd() {
      let item = this.crudItem;
      //清空所有值
      for (var prop in item) {
        item[prop] = null;
      }
    },
    handlePreEdit(val) {
      let item = this.crudItem;
      //赋值所有值
      for (var prop in item) {
        item[prop] = val[prop.substring(0,1).toLowerCase()+prop.substring(1)];
      }
    },
    handleDelete(val) {
      let vm = this;
      vm.$http
        .delete(vm.url + "DeletePerson?Id=" + val.id)
        .then(() => {
          vm.$Message.success("已成功删除");
          vm.fetchData();
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>