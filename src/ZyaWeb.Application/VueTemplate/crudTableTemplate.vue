<style lang="less">
</style>

<template>
    <div>
        <Row>
            <Col span="8">
                <Button id="add" icon="plus-round" type="primary" @click="handlePreAdd">新增</Button>
            </Col>
            <Col span="8" offset="8">
            <slot name="filter"></slot>
            </Col>
        </Row>

        <!-- 弹框 -->
        <Modal v-model="modalIsVisible" :title="_modalTitle"
               :loading="modalIsLoading"
               @on-ok="handleOk">
            <slot name="modal-content"></slot>
            <div v-if="hideModalFooter" slot="footer"></div>
        </Modal>
        <Row class="margin-top-10">
            <Table :columns="columns" :data="tableData" :loading="tableLoading" border
                   @on-sort-change="handleSortChange"></Table>
        </Row>
        <Row class="margin-top-10">
            <Page :total="total"
                  show-sizer=""
                  show-elevator=""
                  :page-size-opts="[10,20,30,40]"
                  :page-size="pageOption.pageSize"
                  :current="pageOption.pageIndex"
                  placement="top"
                  show-total=""
                  @on-change="handlePageChange"
                  @on-page-size-change="handlePageSizeChange"></Page>
        </Row>
    </div>
</template>

<script>
//编辑按钮
const editButton = (vm, h, currentRow, index) => {
  return h('Button', {
         props: {
             icon: 'compose',
             type: 'primary',
             size: 'small'
             },
         style: {
             marginRight: '5px'
             },
         on: {
             click: () => {
                 vm.handlePreEdit(currentRow);
              }
           }
     }, '编辑');
};

//删除按钮
const deleteButton = (vm, h, currentRow, index) => {
    return h('Poptip', {
        props: {
            title: '确定要删除本条数据吗?',
            confirm: true,
            transfer: true
        },
        on: {
            'on-ok': () => {
                vm.handleDelete(currentRow);
            }
        }
    }, [
            h('Button', {
                style: {
                    margin: '0 5px'
                },
                props: {
                    type: 'error',
                    icon: 'trash-a',
                    size: 'small'
                }
            }, '删除')
    ]);
};

//详情按钮
const detailButton = (vm, h, currentRow, index) => {
    return h('Button', {
        style: {
            margin: '0 5px'
        },
        props: {
            type: 'ghost',
            icon: "navicon-round",
            size: 'small'
        },
        on:{
            click: ()=>{
                vm.$emit("on-show-detail", currentRow);
            }
        }
    }, '详情');
};

//下载按钮
const downloadButton = (vm, h, currentRow, index) =>{
    return h('Button',{
        style: {
            margin: '0 5px'
        },
        props:{
            type: 'ghost',
            icon: "arrow-down-a",
            size: 'small'
        },
        on:{
            click: ()=> {
                vm.$emit("on-download", currentRow);
            }
        }
    },'下载')
}

  export default {
    name: 'crud-table',
    props:{
        columns: Array,
        tableData: Array,
        modalTitle: {
            type: String,
            default: ''
            },
        total: {
            type: Number,
            default:1
        },
        pageOption: {
             type: Object,
             default: () => { return { pageIndex: 1, pageSize: 15 }; }
        },
        onOk:{ type: Function },
        tableLoading: false,
        hideModalFooter: false,
        hideModal: false
    },
    data () {
        return {
            modalIsVisible: false,
            modalIsEditting: false,
            modalIsLoading: true
        };
    },
    computed:{
        _modalTitle(){
            return (this.modalIsEditting? '编辑': '新增')+ this.modalTitle;
        }
    },
    created(){
        this.init();
    },
    watch:{
        hideModal:{
            handler: function(val){
                alert(val);
                if(val == true){
                    this.modalIsVisible = !val;
                }
            }
        }
    },
    methods:{
        init(){
            this.columns.forEach(item =>{
                if (item.handle) {
                    item.render = (h, param) => {
                        let currentRowData = this.tableData[param.index];
                        var groups = item.handle.map(x => {
                            switch(x){
                                case 'edit':
                                    return editButton(this, h, currentRowData, param.index);
                                case 'delete':
                                    return deleteButton(this, h, currentRowData, param.index);
                                case 'detail':
                                    return detailButton(this, h, currentRowData, param.index);
                                case 'download':
                                    return downloadButton(this, h, currentRowData, param.index);
                            }
                        });
                        return h('div', groups);
                    };
                }
            })
        },
        handlePageChange(page){
            this.pageOption.pageIndex = page;
            this.$emit('on-page-change', this.pageOption);
        },
        handlePageSizeChange(pageSize){
            this.pageOption.pageSize = pageSize;
            this.$emit('on-page-change', this.pageOption);
        },
        handleSortChange(val){
            if(val.order == 'asc' || val.order == 'desc'){
                this.$emit('on-sort-change', val.key + ' '+ val.order);
            }
        },
        handlePreAdd(){
            this.modalIsEditting = false;
            this.modalIsVisible = true;
            //清空所有的添加项
            this.$emit('on-pre-add');
        },
        handlePreEdit(row){
            this.modalIsEditting = true;
            this.modalIsVisible = true;
            //将当前行赋值给modal的显示
            this.$emit('on-pre-edit', row);
        },
        handleDelete(row){
            //删除当前行, 返回当前行
            this.$emit('on-delete', row);
        },
        handleOk(){
            let vm = this;
            if(vm.onOk){
                vm.onOk().then((valid) => {
                    if(valid){
                        var msg = vm.modalIsEditting ? "已成功修改": "已成功新增";
                        vm.modalIsVisible = false;
                        vm.$Message.success(msg);
                    }else{
                        vm.modalIsLoading = false;
                        vm.$nextTick(() => { vm.modalIsLoading = true; });
                    }
                });
            }
        }
    }
};
</script>
