namespace G_Pigmy.App.DataControl.Helper.Constant
{
    public static class PartitionKey
    {
        public static readonly string AGENT_PARTITION_KEY = "Data";
        public static readonly string CUSTOMER_PARTITION_KEY = "Data";
        public static readonly string TRANSACTION_PARTITION_KEY = "Data";



        public static readonly string AGENT_PARTITION_INDEX = "Agent_Code";
        public static readonly string CUSTOMER_PARTITION_INDEX = "Customer_AccNo";
        public static readonly string AGENT_BRANCH_CODE_PARTITION_INDEX = "Agent_BranchCode";
        public static readonly string CUSTOMER_ACCOUNTID_PARTITION_INDEX = "Customer_AccNo";
        public static readonly string CUSTOMER_BRANCH_PARTITION_INDEX = "Customer_BranchCode";
        public static readonly string USER_USERNAME_PARTITION_INDEX = "Users_Username";
        
    }
}
