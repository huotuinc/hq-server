var JQueue = {
	array: [],
	/**
	 * @brief: 元素入队
	 * @param: vElement元素列表,每个元素(必须包含ID唯一属性)
	 * @return: 返回当前队列元素个数
	 * @remark: 1.EnQueue方法参数可以多个
	 * 2.参数为空时返回-1
	 */
	PutQueue: function (vElement) {
		if (arguments == undefined && arguments.length == 0)
			return -1; //元素入队
		for (var i = 0; i < arguments.length; i++) {
			var _index = JQueue.FindIndex(arguments[i].ID);
			if (_index == -1) {//不存在则新增
				JQueue.array.push(arguments[i]);
			}
			else {//存在则修改
				JQueue.array.PatchQueue(arguments[i]);
			}
		}
		return JQueue.array.length;
	},
	/**
	 *@brief 队列物理删除
	 */
	Delete: function (id) {
		for (var i = 0; i < JQueue.array.length; i++) {
			if (JQueue.array[i] != null && JQueue.array[i].length != 0 && JQueue.array[i].ID.length != 0) {
				if (JQueue.array[i].ID == id) {
					JQueue.array.splice(i, 1);
				}
			}
		}
	},
	/**
	 *@brief:根据队列唯一ID来修改该队列元素信息
	 *@param: id(队列元素的唯一标识)
	 *@return:返回队列修改后的元素
	 */
	FindIndex: function (id) {
		for (var i = 0; i < JQueue.array.length; i++) {
			if (JQueue.array[i] != null && JQueue.array[i].length != 0 && JQueue.array[i].ID.length != 0) {
				if (JQueue.array[i].ID == id) {
					return i;
				}
			}
		}
		return -1;
	},
	/**
	 * @brief: 将队列置空
	 */
	Empty: function () {
		JQueue.array.length = 0;
	},
}